﻿using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Utils.Converter;

public static class SensorConvertor
{
    public static SensorDto ToListDto(this Sensor sensor)
    {
        if (sensor == null)
            throw new Exception("Sensor is null.");
        return new SensorDto
        {
            Id = sensor.Id,
            SensorName = sensor.SensorName,
            MinValue = sensor.MinValue,
            AvgValue = sensor.AvgValue,
            MaxValue = sensor.MaxValue,
        };
    }
    
    public static SensorDto ToDto(this Sensor sensor)
    {
        return new SensorDto
        {
            Id = sensor.Id,
            SensorName = sensor.SensorName,
            MinValue = sensor.MinValue,
            AvgValue = sensor.AvgValue,
            MaxValue = sensor.MaxValue,
        };
    }
    
    public static Sensor ToEntity(this SensorForCreationDto sensorDto, int systemId)
    {
        var sensor = new Sensor
        {
            Id = sensorDto.Id,
            SensorName = sensorDto.SensorName,
            CarSystemId = systemId,
            MinValue = sensorDto.MinValue,
            MaxValue = sensorDto.MaxValue,
            AvgValue = sensorDto.AvgValue
        };

        return sensor;
    }
    public static Sensor ToEntity(this SensorForCreationDto sensorDto)
    {
        var sensor = new Sensor
        {
            Id = sensorDto.Id,
            SensorName = sensorDto.SensorName,
            MinValue = sensorDto.MinValue,
            MaxValue = sensorDto.MaxValue,
            AvgValue = sensorDto.AvgValue
        };

        return sensor;
    }
    
    public static SensorForUpdateDto ToUpdateDto(this SensorDto sensorDto, int carSystemId)
    {
        return new SensorForUpdateDto
        {
            SensorName = sensorDto.SensorName,
            CarSystemId = carSystemId,
            MinValue = sensorDto.MinValue,
            MaxValue = sensorDto.MaxValue,
            AvgValue = sensorDto.AvgValue
        };
    }
    
    public static PagedList<SensorDto> ToListDto(this PagedList<Sensor> sensors)
    {
        var count = sensors.TotalCount;
        var pageNumber = sensors.CurrentPage;
        var pageSize = sensors.PageSize;
        var totalPages = sensors.TotalPages;
        return new PagedList<SensorDto>(
            sensors.Select(s => s.ToListDto()).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
    public static Sensor ToSensorEntity(this SensorForUpdateDto sensorForUpdate, ref Sensor sensor)
    {
        sensor.SensorName = sensorForUpdate.SensorName;
        sensor.CarSystemId = sensorForUpdate.CarSystemId;
        sensor.MinValue = sensorForUpdate.MinValue;
        sensor.MaxValue = sensorForUpdate.MaxValue;
        sensor.AvgValue = sensorForUpdate.AvgValue;
        return sensor;
    }
}
