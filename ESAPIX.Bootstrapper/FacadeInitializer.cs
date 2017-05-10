#region

using ESAPIX.Facade;
using V = VMS.TPS.Common.Model.API;
using X = ESAPIX.Facade.API;
using T = VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Bootstrapper
{
    public class FacadeInitializer
    {
        public static void Initialize()
        {
            //DO STATIC METHOD MAPS
            StaticHelper.CreateApplicationFunc = (user, pw) => { return V.Application.CreateApplication(user, pw); };

            StaticHelper.DoseValue_UndefinedDoseFunc = () => T.DoseValue.UndefinedDose();
            StaticHelper.SerializableObject_ClearSerializationHistoryAction =
                () => V.SerializableObject.ClearSerializationHistory();
            StaticHelper.VVector_DistanceFunc = (v1, v2) => T.VVector.Distance(v1, v2);


            VMSConstructor.ConstructScriptContextFunc0 = (context, user, appName) =>
            {
                return new VMS.TPS.Common.Model.API.ScriptContext(context, user);
            };
            VMSConstructor.ConstructVVectorFunc0 = (xi, yi, zi) => { return new T.VVector(xi, yi, zi); };

            VMSConstructor.ConstructSegmentProfileFunc0 = (origin, step, data) =>
            {
                return new T.SegmentProfile(origin, step, data);
            };
            VMSConstructor.ConstructSegmentProfilePointFunc0 = (position, value) =>
            {
                return new T.SegmentProfilePoint(position, value);
            };
            VMSConstructor.ConstructDoseValueFunc0 = (value, unitName) => { return new T.DoseValue(value, unitName); };
            VMSConstructor.ConstructDoseValueFunc1 = (value, unit) =>
            {
                return new T.DoseValue(value, (T.DoseValue.DoseUnit)unit);
            };
            VMSConstructor.ConstructProfilePointFunc0 = (position, value) =>
            {
                return new T.ProfilePoint(position, value);
            };
            VMSConstructor.ConstructDoseProfileFunc0 = (origin, step, data, unit) =>
            {
                return new T.DoseProfile(origin, step, data, (T.DoseValue.DoseUnit)unit);
            };
            VMSConstructor.ConstructDVHPointFunc0 = (dose, volume, volumeUnit) =>
            {
                return new T.DVHPoint(dose, volume, volumeUnit);
            };
            VMSConstructor.ConstructVRectFunc0 = (x1, y1, x2, y2) => { return new T.VRect<double>(x1, y1, x2, y2); };
            VMSConstructor.ConstructMetersetValueFunc0 = (value, unit) =>
            {
                return new T.MetersetValue(value, (T.DosimeterUnit)unit);
            };
            VMSConstructor.ConstructImageProfileFunc0 = (origin, step, data, unit) =>
            {
                return new T.ImageProfile(origin, step, data, unit);
            };
        }
    }
}