using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Personal.Expenses.Application.Interfaces;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;
using Personal.Expenses.Domain.Interfaces.Services;
using Personal.Expenses.Dto;
using System.Threading.Tasks;
using Common.Domain.Model;
using System.Collections.Generic;
using AutoMapper;

namespace Personal.Expenses.Application
{
    public class SpentApplicationServiceBase : ApplicationServiceBase<Spent, SpentDto, SpentFilter>, ISpentApplicationService
    {
        protected readonly ValidatorAnnotations<SpentDto> _validatorAnnotations;
        protected readonly ISpentService _service;
        protected readonly CurrentUser _user;

        public SpentApplicationServiceBase(ISpentService service, IUnitOfWork uow, ICache cache, CurrentUser user, IMapper mapper) :
            base(service, uow, cache, mapper, user)
        {
            base.SetTagNameCache("Spent");
            this._validatorAnnotations = new ValidatorAnnotations<SpentDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<Spent> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as SpentDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<Spent>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<Spent>();
			foreach (var dto in dtos)
			{
				var _dto = dto as SpentDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<Spent> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as SpentDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
