﻿using System.ComponentModel.DataAnnotations;
using DataLayer.DataClasses.Concrete;
using GenericServices.Core;

namespace Tests.Helpers
{
    class SimpleTagDtoAsync : InstrumentedEfGenericDtoAsync<Tag, SimpleTagDtoAsync>
    {

        private ServiceFunctions _supportedFunctionsToUse = ServiceFunctions.AllCrud |
                                                    ServiceFunctions.DoAction |
                                                    ServiceFunctions.DoDbAction;

        public SimpleTagDtoAsync()
        {
        }

        public SimpleTagDtoAsync(InstrumentedOpFlags whereToFail)
            : base(whereToFail)
        {
        }


        [Key]
        public int TagId { get; set; }

        [MaxLength(64)]
        [Required]
        [RegularExpression(@"\w*", ErrorMessage = "The slug must not contain spaces or non-alphanumeric characters.")]
        public string Slug { get; set; }

        [MaxLength(128)]
        [Required]
        public string Name { get; set; }


        //--------------------------------------


        protected internal override ServiceFunctions SupportedFunctions
        {
            get { return _supportedFunctionsToUse; }
        }

        public void SetSupportedFunctions(ServiceFunctions allowedFunctions)
        {
            _supportedFunctionsToUse = allowedFunctions;
        }

    }
}