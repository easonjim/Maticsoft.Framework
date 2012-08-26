﻿namespace Maticsoft.Web.Validator
{
    using System.Globalization;

    public class MoneyRangeClientValidator : ClientValidator
    {
        private decimal maxValue = 79228162514264337593543950335M;
        private decimal minValue = -79228162514264337593543950335M;

        internal override ValidateRenderControl GenerateAppendScript()
        {
            return new ValidateRenderControl { Text = string.Format(CultureInfo.InvariantCulture, "appendValid(new MoneyRangeValidator('{0}', {1}, {2}, '{3}', '{4}'));", new object[] { base.Owner.TargetClientId, this.MinValue, this.MaxValue, this.ErrorMessage, base.Owner.OkMessage }) };
        }

        internal override ValidateRenderControl GenerateInitScript()
        {
            return new ValidateRenderControl();
        }

        public decimal MaxValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {
                this.maxValue = value;
            }
        }

        public decimal MinValue
        {
            get
            {
                return this.minValue;
            }
            set
            {
                this.minValue = value;
            }
        }
    }
}