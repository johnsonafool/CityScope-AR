/*using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class currentDataParameter
{
    public string parameterName;
    public string parameterValue;
}

[Serializable]
public class currentDataWeatherElement
{
    public string elementName;
    public string elementValue;
}
[Serializable]
public class currentDataTime
{
    public string obsTime;
}

[Serializable]
public class currentDataLocation
{
    public string lat;
    public string lon;
    public string locationName;
    public string stationId;
    public currentDataTime time;
    public currentDataWeatherElement[] weatherElement;
    public currentDataParameter[] parameter;
}

[Serializable]
public class elementValue
{
    public string value;
    public string measures;
}

[Serializable]
public class time
{
    public string startTime;
    public string endTime;
    public elementValue[] elementValue;
}

[Serializable]
public class weatherElement
{
    public string elementName;
    public string description;
    public time[] time;
}

[Serializable]
public class location
{
    public string locationName;
    public string geocode;
    public string lat;
    public string lon;
    public weatherElement[] weatherElement;
}

[Serializable] 
public class locations
{
    public string datasetDescription;
    public string locationsName;
    public string dataid;
    public location[] location;
}

[Serializable]
public class records
{
    public locations[] locations;
    public currentDataLocation[] location;
}

[Serializable]
public class jsonObj
{
    public string success;
    public records records;
}
*/