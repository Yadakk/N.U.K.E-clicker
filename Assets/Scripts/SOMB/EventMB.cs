using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;
using Utilities;
using System.Linq;
using System;
using System.Xml.Linq;
using Unity.VisualScripting;
using static PositivityColorSchemes;

public class EventMB : MonoBehaviour
{
    [field: SerializeField] public EventData Data { get; private set; }
}

[Serializable]
public class EventData
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Desc { get; private set; }
    [field: SerializeField] public string PositiveName { get; private set; }
    [field: SerializeField] public EventBundle PositiveEffects { get; private set; }
    [field: SerializeField] public string NegativeName { get; private set; }
    [field: SerializeField] public EventBundle NegativeEffects { get; private set; }
}

[System.Serializable]
public class EventBundle
{
    [field: SerializeField] public EventResourceChange[] ResourceChanges { get; private set; }
    [field: SerializeField] public EventResourceRandomChange[] ResourceRandomChanges { get; private set; }
    [field: SerializeField] public EventResourceRandomChangePerResourceChanges[] ResourceRandomChangesPerResourceChanges { get; private set; }

    public EventResource[] GetAllResources()
    {
        var properties = typeof(EventBundle).GetProperties();
        List<EventResource> evResources = new();
        foreach (var property in properties)
        {
            object obj = property.GetValue(this);
            object[] objArray = ((IEnumerable)obj).Cast<object>()
                                   .Select(x => x == null ? x : Convert.ChangeType(x, typeof(EventResource)))
                                   .ToArray();
            EventResource[] evResArray = Array.ConvertAll(objArray, new Converter<object, EventResource>(obj => (EventResource)Convert.ChangeType(obj, typeof(EventResource))));
            foreach(var evRes in evResArray)
                evResources.Add(evRes);
        }
        return evResources.ToArray();
    }

    public bool HasChanges() => GetAllResources().Length != 0;
}

public abstract class EventResource
{
    [field: SerializeField] public Resource Resource { get; private set; }
    public abstract void ApplyChanges();
    public abstract string FormatResourceChange();
}

[Serializable]
public class EventResourceChange : EventResource, IConvertible
{
    [field: SerializeField] public float Change { get; private set; }
    [field: SerializeField] public bool IsPercentChange { get; private set; }

    public override void ApplyChanges()
    {
        Resource.Amount += IsPercentChange ? Mathf.Round(Resource.Amount / 100 * Change) : Change;
    }

    public override string FormatResourceChange()
    {
        StringBuilder builder = new();
        PositivityColorScheme colorScheme = PositivityToColorScheme(Resource);
        FormatNumber(ref builder, colorScheme, Change, IsPercentChange || Resource.IsPercentFormatted);
        builder.Append(" ");
        builder.Append(Resource.Name);
        builder.Append("</color>");
        return builder.ToString();
    }

    #region IConvertible Implementation
    public TypeCode GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public bool ToBoolean(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public byte ToByte(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public char ToChar(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public DateTime ToDateTime(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public decimal ToDecimal(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public double ToDouble(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public short ToInt16(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public int ToInt32(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public long ToInt64(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public float ToSingle(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public string ToString(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public object ToType(Type conversionType, IFormatProvider provider)
    {
        if (conversionType == typeof(EventResource))
        {
            return this;
        }

        throw new NotImplementedException();
    }

    public ushort ToUInt16(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public uint ToUInt32(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }
    #endregion
}

[Serializable]
public class EventResourceRandomChange : EventResource, IConvertible
{
    [field: SerializeField] public float MinChange { get; private set; }
    [field: SerializeField] public float MaxChange { get; private set; }
    [field: SerializeField] public bool IsPercentChange { get; private set; }
    public float Next { get => UnityEngine.Random.Range((int)MinChange, (int)MaxChange); }

    public override void ApplyChanges()
    {
        Resource.Amount += IsPercentChange ? Mathf.Round(Resource.Amount / 100 * Next) : Next;
    }

    public override string FormatResourceChange()
    {
        StringBuilder builder = new();
        PositivityColorScheme colorScheme = PositivityToColorScheme(Resource);
        builder.Append("From ");
        FormatNumber(ref builder, colorScheme, MinChange, IsPercentChange || Resource.IsPercentFormatted);
        builder.Append(" To ");
        FormatNumber(ref builder, colorScheme, MaxChange, IsPercentChange || Resource.IsPercentFormatted);
        builder.Append(" ");
        builder.Append(Resource.Name);
        return builder.ToString();
    }

    #region IConvertible Implementation
    public TypeCode GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public bool ToBoolean(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public byte ToByte(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public char ToChar(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public DateTime ToDateTime(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public decimal ToDecimal(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public double ToDouble(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public short ToInt16(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public int ToInt32(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public long ToInt64(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public float ToSingle(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public string ToString(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public object ToType(Type conversionType, IFormatProvider provider)
    {
        if (conversionType == typeof(EventResource))
        {
            return this;
        }

        throw new NotImplementedException();
    }

    public ushort ToUInt16(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public uint ToUInt32(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }
    #endregion
}

[Serializable]
public class EventResourceRandomChangePerResourceChanges : EventResourceChange, IConvertible
{
    [field: SerializeField] public EventResourceRandomChange[] EventResourceRandomChanges { get; private set; }

    public override void ApplyChanges()
    {
        float resChange = IsPercentChange ? Mathf.Round(Resource.Amount / 100 * Change) : Change;
        Resource.Amount += resChange;
        foreach (var change in EventResourceRandomChanges)
        {
            for (int i = 0; i < Mathf.Abs(resChange); i++)
            {
                change.ApplyChanges();
            }
        }
    }

    public override string FormatResourceChange()
    {
        StringBuilder mainBuilder = new();
        PositivityColorScheme mainColorScheme = PositivityToColorScheme(Resource);
        FormatNumber(ref mainBuilder, mainColorScheme, Change, IsPercentChange || Resource.IsPercentFormatted);
        mainBuilder.Append(" ");
        mainBuilder.Append(Resource.Name);
        mainBuilder.AppendLine("</color>");
        mainBuilder.Append("For each unit of ");
        mainBuilder.Append(Resource.Name);
        mainBuilder.AppendLine(": ");
        mainBuilder.AppendLine("-----");
        foreach (var change in EventResourceRandomChanges)
        {
            StringBuilder builder = new();
            PositivityColorScheme colorScheme = PositivityToColorScheme(Resource);
            builder.Append("From ");
            FormatNumber(ref builder, colorScheme, change.MinChange, change.IsPercentChange || change.Resource.IsPercentFormatted);
            builder.Append(" To ");
            FormatNumber(ref builder, colorScheme, change.MaxChange, change.IsPercentChange || change.Resource.IsPercentFormatted);
            builder.Append(" ");
            builder.Append(change.Resource.Name);
            mainBuilder.AppendLine(builder.ToString());
        }
        mainBuilder.Append("-----");
        return mainBuilder.ToString();
    }
}