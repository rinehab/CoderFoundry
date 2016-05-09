//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(CoderFoundry.HCL2Services.HCL2Entities),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets9403d14c4c56d74b188b8fa998b97752920c786279dcbfcb6574408fc240289e))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework Power Tools", "0.9.0.0")]
    internal sealed class ViewsForBaseEntitySets9403d14c4c56d74b188b8fa998b97752920c786279dcbfcb6574408fc240289e : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "9403d14c4c56d74b188b8fa998b97752920c786279dcbfcb6574408fc240289e"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "HCL2ModelStoreContainer.Cars")
            {
                return GetView0();
            }

            if (extentName == "HCL2Entities.Cars")
            {
                return GetView1();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for HCL2ModelStoreContainer.Cars.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Cars
        [HCL2Model.Store.Cars](T1.Cars_id, T1.Cars_make, T1.[Cars.model_name], T1.[Cars.model_trim], T1.[Cars.model_year], T1.[Cars.body_style], T1.[Cars.engine_position], T1.[Cars.engine_cc], T1.[Cars.engine_num_cyl], T1.[Cars.engine_type], T1.[Cars.engine_valves_per_cyl], T1.[Cars.engine_power_ps], T1.[Cars.engine_power_rpm], T1.[Cars.engine_torque_nm], T1.[Cars.engine_torque_rpm], T1.[Cars.engine_bore_mm], T1.[Cars.engine_stroke_mm], T1.[Cars.engine_compression], T1.[Cars.engine_fuel], T1.[Cars.top_speed_kph], T1.[Cars.zero_to_100_kph], T1.[Cars.drive_type], T1.[Cars.transmission_type], T1.Cars_seats, T1.Cars_doors, T1.[Cars.weight_kg], T1.[Cars.length_mm], T1.[Cars.width_mm], T1.[Cars.height_mm], T1.Cars_wheelbase, T1.[Cars.lkm_hwy], T1.[Cars.lkm_mixed], T1.[Cars.lkm_city], T1.[Cars.fuel_capacity_l], T1.[Cars.sold_in_us], T1.Cars_co2, T1.[Cars.make_display])
    FROM (
        SELECT 
            T.id AS Cars_id, 
            T.make AS Cars_make, 
            T.model_name AS [Cars.model_name], 
            T.model_trim AS [Cars.model_trim], 
            T.model_year AS [Cars.model_year], 
            T.body_style AS [Cars.body_style], 
            T.engine_position AS [Cars.engine_position], 
            T.engine_cc AS [Cars.engine_cc], 
            T.engine_num_cyl AS [Cars.engine_num_cyl], 
            T.engine_type AS [Cars.engine_type], 
            T.engine_valves_per_cyl AS [Cars.engine_valves_per_cyl], 
            T.engine_power_ps AS [Cars.engine_power_ps], 
            T.engine_power_rpm AS [Cars.engine_power_rpm], 
            T.engine_torque_nm AS [Cars.engine_torque_nm], 
            T.engine_torque_rpm AS [Cars.engine_torque_rpm], 
            T.engine_bore_mm AS [Cars.engine_bore_mm], 
            T.engine_stroke_mm AS [Cars.engine_stroke_mm], 
            T.engine_compression AS [Cars.engine_compression], 
            T.engine_fuel AS [Cars.engine_fuel], 
            T.top_speed_kph AS [Cars.top_speed_kph], 
            T.zero_to_100_kph AS [Cars.zero_to_100_kph], 
            T.drive_type AS [Cars.drive_type], 
            T.transmission_type AS [Cars.transmission_type], 
            T.seats AS Cars_seats, 
            T.doors AS Cars_doors, 
            T.weight_kg AS [Cars.weight_kg], 
            T.length_mm AS [Cars.length_mm], 
            T.width_mm AS [Cars.width_mm], 
            T.height_mm AS [Cars.height_mm], 
            T.wheelbase AS Cars_wheelbase, 
            T.lkm_hwy AS [Cars.lkm_hwy], 
            T.lkm_mixed AS [Cars.lkm_mixed], 
            T.lkm_city AS [Cars.lkm_city], 
            T.fuel_capacity_l AS [Cars.fuel_capacity_l], 
            T.sold_in_us AS [Cars.sold_in_us], 
            T.co2 AS Cars_co2, 
            T.make_display AS [Cars.make_display], 
            True AS _from0
        FROM HCL2Entities.Cars AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for HCL2Entities.Cars.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Cars
        [HCL2Model.Car](T1.Car_id, T1.Car_make, T1.[Car.model_name], T1.[Car.model_trim], T1.[Car.model_year], T1.[Car.body_style], T1.[Car.engine_position], T1.[Car.engine_cc], T1.[Car.engine_num_cyl], T1.[Car.engine_type], T1.[Car.engine_valves_per_cyl], T1.[Car.engine_power_ps], T1.[Car.engine_power_rpm], T1.[Car.engine_torque_nm], T1.[Car.engine_torque_rpm], T1.[Car.engine_bore_mm], T1.[Car.engine_stroke_mm], T1.[Car.engine_compression], T1.[Car.engine_fuel], T1.[Car.top_speed_kph], T1.[Car.zero_to_100_kph], T1.[Car.drive_type], T1.[Car.transmission_type], T1.Car_seats, T1.Car_doors, T1.[Car.weight_kg], T1.[Car.length_mm], T1.[Car.width_mm], T1.[Car.height_mm], T1.Car_wheelbase, T1.[Car.lkm_hwy], T1.[Car.lkm_mixed], T1.[Car.lkm_city], T1.[Car.fuel_capacity_l], T1.[Car.sold_in_us], T1.Car_co2, T1.[Car.make_display])
    FROM (
        SELECT 
            T.id AS Car_id, 
            T.make AS Car_make, 
            T.model_name AS [Car.model_name], 
            T.model_trim AS [Car.model_trim], 
            T.model_year AS [Car.model_year], 
            T.body_style AS [Car.body_style], 
            T.engine_position AS [Car.engine_position], 
            T.engine_cc AS [Car.engine_cc], 
            T.engine_num_cyl AS [Car.engine_num_cyl], 
            T.engine_type AS [Car.engine_type], 
            T.engine_valves_per_cyl AS [Car.engine_valves_per_cyl], 
            T.engine_power_ps AS [Car.engine_power_ps], 
            T.engine_power_rpm AS [Car.engine_power_rpm], 
            T.engine_torque_nm AS [Car.engine_torque_nm], 
            T.engine_torque_rpm AS [Car.engine_torque_rpm], 
            T.engine_bore_mm AS [Car.engine_bore_mm], 
            T.engine_stroke_mm AS [Car.engine_stroke_mm], 
            T.engine_compression AS [Car.engine_compression], 
            T.engine_fuel AS [Car.engine_fuel], 
            T.top_speed_kph AS [Car.top_speed_kph], 
            T.zero_to_100_kph AS [Car.zero_to_100_kph], 
            T.drive_type AS [Car.drive_type], 
            T.transmission_type AS [Car.transmission_type], 
            T.seats AS Car_seats, 
            T.doors AS Car_doors, 
            T.weight_kg AS [Car.weight_kg], 
            T.length_mm AS [Car.length_mm], 
            T.width_mm AS [Car.width_mm], 
            T.height_mm AS [Car.height_mm], 
            T.wheelbase AS Car_wheelbase, 
            T.lkm_hwy AS [Car.lkm_hwy], 
            T.lkm_mixed AS [Car.lkm_mixed], 
            T.lkm_city AS [Car.lkm_city], 
            T.fuel_capacity_l AS [Car.fuel_capacity_l], 
            T.sold_in_us AS [Car.sold_in_us], 
            T.co2 AS Car_co2, 
            T.make_display AS [Car.make_display], 
            True AS _from0
        FROM HCL2ModelStoreContainer.Cars AS T
    ) AS T1");
        }
    }
}
