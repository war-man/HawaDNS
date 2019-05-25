﻿using System;

using _Common.Extensions;
using _Common.Helpers;
using _Common.Timing;
using _Constants.EntityTypes;
using _Dtos.IC;
using _Entities.IC;

namespace _Services.ConvertHelpers
{
    public static class ICEntityToDtoConvertHelper
    {
        public static TreeSpecDto ToTreeSpecDto(this ICTreeSpec entity)
        {
            return entity == null
                ? null
                : new TreeSpecDto
                {
                    Id = entity.Id,
                    Name = entity.ICTreeSpecName,
                    Acronym = entity.ICTreeSpecAcronym,
                    GeoDistribution = entity.ICTreeSpecGeoDistribution,
                    IsSpecialProduct = entity.ICTreeSpecIsSpecialProduct,
                    Latin = entity.ICTreeSpecLatin
                };
        }

        public static ForestPlotDetailDto ToForestPlotDetailDto(this ICForestPlot entity)
        {
            return entity == null
                ? null
                : new ForestPlotDetailDto
                {
                    Id = entity.Id,
                    Area = entity.ICForestPlotArea,
                    PlantingYear = entity.ICForestPlotPlantingYear.GetValueOrDefault() == 0 ? 0 : (Clock.Now.Year - entity.ICForestPlotPlantingYear.GetValueOrDefault()),
                    TreeSpec = entity.ICTreeSpec.ToTreeSpecDto(),
                    CompartmentCode = entity.GECompartment?.GECompartmentCode,
                    SubCompartmentCode = entity.GESubCompartment?.GESubCompartmentCode,
                    PlotCode = entity.GEPlotCode,
                    PlantingDate = entity.ICForestPlotPlantingDate.ToSecondsTimestamp(),
                    //Dispute = entity.ICForestPlotDispute.ToDictionaryItemDto<ForestPlotDispute>(),
                    Actor = entity.APActor.ToActorDto(),
                    ActorType = entity.APActor?.APActorType.ToActorTypeDto(),
                    Compartment = entity.GECompartment.ToDictionaryItemDto(),
                    ForestCert = entity.ICForestCert.ToDictionaryItemDto(),
                    Plot = null, //TOdo mapping
                    SubCompartment = entity.GESubCompartment.ToDictionaryItemDto(),
                    VolumnPerPlot = entity.ICForestPlotVolumnPerPlot,
                    Reliability = entity.ICForestPlotReliability.ToDictionaryItemDto<ForestPlotReliability>(),
                    LandUseCert = entity.GEDisICLandUseCerttrict.ToDictionaryItemDto(),
                    ConflictSitCode = Convert.ToInt32(entity.ICConflictSitCode),
                    LocationLatitude = entity.ICForestPlotLocationLatitude,
                    LocationLongitude = entity.ICForestPlotLocationLongitude,
                };
        }

        public static TreeSpecGroupDto ToTreeSpecGroupDto(this ICTreeSpecGroup entity)
        {
            return entity == null
                ? null
                : new TreeSpecGroupDto
                {
                    Id = entity.Id,
                    Desc = entity.ICTreeSpecGroupDesc,
                    Name = entity.ICTreeSpecGroupName,
                    TreeSpecs = entity.ICTreeSpecGroupItems.ConvertArray(x => x.ICTreeSpec.ToTreeSpecDto()),
                    CreatedDate = entity.AACreatedDate.ToSecondsTimestamp()
                };
        }

        public static ForestPlotDto ToForestPlotDto(this ICPlot entity)
        {
            return entity == null
                ? null
                : new ForestPlotDto
                {
                    Area = entity.ICPlotArea.GetValueOrDefault(),
                    VolumnPerPlot = entity.ICPlotVolumnPerPlot.GetValueOrDefault(),
                    Commune = entity.GECommune.ToDictionaryItemDto(),
                    District = entity.GECommune?.GEDistrict.ToDictionaryItemDto(),
                    StateProvince = entity.GECommune?.GEDistrict?.GEStateProvince.ToDictionaryItemDto(),
                    TreeSpec = entity.ICTreeSpec.ToTreeSpecDto(),
                    LocationLatitudeCommune = entity.GECommune?.GECommuneLocationLatitude,
                    LocationLongitudeCommune = entity.GECommune?.GECommuneLocationLongitude,
                };
        }

        public static ForestPlotDto ToForestPlotDto(this ICForestPlot entity)
        {
            return entity == null
                ? null
                : new ForestPlotDto
                {
                    Area = entity.ICForestPlotArea,
                    VolumnPerPlot = entity.ICForestPlotVolumnPerPlot,
                    Commune = entity.GECommunes.ToDictionaryItemDto(),
                    District = entity.GEDistrict.ToDictionaryItemDto(),
                    StateProvince = entity.GEStateProvince.ToDictionaryItemDto(),
                    TreeSpec = entity.ICTreeSpec.ToTreeSpecDto(),
                    Compartment = entity.GECompartment.ToDictionaryItemDto(),
                    SubCompartment = entity.GESubCompartment.ToDictionaryItemDto(),
                    PlotCode = entity.GEPlotCode,
                    Id = entity.Id
                };
        }
    }
}