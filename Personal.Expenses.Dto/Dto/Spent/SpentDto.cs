using System.ComponentModel.DataAnnotations;
using Common.Domain.Base;
using System;

namespace Personal.Expenses.Dto
{
	public class SpentDto  : DtoBase
	{
	
        

        public virtual int SpentId {get; set;}

        [Required(ErrorMessage="Spent - Campo Description é Obrigatório")]
        [MaxLength(250, ErrorMessage = "Spent - Quantidade de caracteres maior que o permitido para o campo Description")]
        public virtual string Description {get; set;}


		
	}
}
