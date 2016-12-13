﻿using System;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.DVH.Constraints
{
    public class MinVolAtDoseConstraint : VolumeAtDoseConstraint
    {
        public MinVolAtDoseConstraint()
        {
            PassingFunc = new Func<double, bool>((vol => { return vol >= Volume; }));
        }

        public override string ToString()
        {
            //Mayo format
            var vol = Volume.ToString("N1");
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"V{dose}{doseUnit}[{volUnit}]>={vol}";
        }
    }
}
