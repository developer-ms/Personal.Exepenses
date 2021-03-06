﻿using Common.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Personal.Expenses.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CacheListClearController : Controller
    {
        private readonly ICache _cache;

        public CacheListClearController(ICache cache)
        {
            this._cache = cache;
        }

        [HttpGet]
        public IActionResult Get(string key)
        {
            if (key.IsNotNullOrEmpty())
                return Ok(this._cache.Get<dynamic>(key));

            var pathBase = AppDomain.CurrentDomain.BaseDirectory;
            var assembly = Assembly.LoadFrom(Path.Combine(pathBase, "Personal.Expenses.Domain.dll"));
            var result = new List<dynamic>();
            foreach (Type type in assembly.GetTypes()
                .Where(_ => _.Namespace.Contains(".Domain.Entitys")))
            {
                if (!type.FullName.Contains("+") && !type.FullName.ToLower().Contains("base"))
                {
                    var group = type.Name;
                    var keys = this._cache.Get<List<string>>(group);
                    if (keys.IsAny())
                    {
                        result.Add(new
                        {
                            group,
                            Keys = keys
                        });
                    }
                }
            }

            foreach (var item in result)
            {
                foreach (string subItem in item.Keys)
                {
                    this._cache.Remove(subItem);
                }
                this._cache.Remove(item.group);
            }

            return Ok("Clear End");
        }
    }
}
