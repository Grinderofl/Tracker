using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tracker.Core
{
    public class DateTimeModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            DateTime? parsed;
            if (string.IsNullOrWhiteSpace(value.AttemptedValue)) return null;
            try
            {
                parsed = DateTime.ParseExact(value.AttemptedValue, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                parsed = DateTime.Parse(value.AttemptedValue);
            }

            return parsed;
        }
    }
}