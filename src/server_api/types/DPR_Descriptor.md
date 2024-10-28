---
layout: page
title: "Descriptor" 
---
    
Այս դասը նախատեսված է [DPR](../definitions/dpr.md)-ի մետատվյալների նկարագրման համար։

Օգտագործվում է [IJobServerClient](../services/IJobServerClient.md).[Enqueue](../services/IJobServerClient.md#enqueue) մեթոդով [DPR](../definitions/dpr.md)-ի կատարումը հերթի դնելիս։
    
public class Descriptor
{
    public string Name { get; private set; }
    public DPRType DPRType { get; private set; }
    public string ArmenianCaption { get; private set; }
    public string EnglishCaption { get; private set; }
    public Type Type { get; private set; }
    public uint Version { get; private set; }
    public bool IsDynamic { get; private set; }
    public FeatureAvailability IsCancellationSupported { get; private set; } = FeatureAvailability.Enabled;
}

* `Name` - [DPR](../definitions/dpr.md)-ի ներքին անունը:
* `DPRType` - [DPR](../definitions/dpr.md)-ի տեսակը։
* `ArmenianCaption` - [DPR](../definitions/dpr.md)-ի հայերեն անվանումը:
* `EnglishCaption` - [DPR](../definitions/dpr.md)-ի անգլերեն անվանումը:
* `Type` - [DPR](../definitions/dpr.md)-ի տեսակը:
           DPRType.Report - Հաշվետվությունների տվյալների մշակման հարցում
           DPRType.OLAP - Օլապ տվյալների մշակման հարցում
           DPRType.JobElement - Առաջադրանքների տվյալների մշակման հարցում
           DPRType.Other - Այլ տվյալների մշակման հարցում
* `Version` - DPR-ի տարբերակի համարը։ 
* `IsDynamic` - Ցույց է տալիս, արդյոք [DPR](../definitions/dpr.md)-ը հանդիսանում է [կազմակերպության սեփական նկարագրություն](../../extensions/definitions/dpr_new_guide.md), թե ոչ։ 
* `IsCancellationSupported` - Ցույց է տալիս, արդյոք հնարավոր է դադարեցնել [DPR](../definitions/dpr.md)-ի կատարումը UI-ից։