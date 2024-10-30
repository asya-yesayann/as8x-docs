---
layout: page
title: "SessionInfo դաս" 
---

Ծրագիր մուտք գործելիս բացվում է սեսսիա, որը պարունակում է մուտք գործած օգտատիրոջ տվյալները և ծրագրի աշխատանքի որոշ կարգավորումներ: 
Սեսսիան ավտոմատ կերպով փակվում է ծրագրից դուրս գալիս։

Սեսսիայի փակման հետ համատեղ հեռացվում են նաև սեսսիայի ընթացքում առաջացած ժամանակավոր ֆայլերը, ընդհատվում ընթացիկ job-երը։

Ընթացիկ սեսսիան ստացվում է [ISessionInfoService](../services/ISessionInfoService.md).[GetInfo](../services/ISessionInfoService.md#getinfo) Մեթոդով։

Սեսսիայի մասին ինֆորմացիան պահվում է տվյալների պահոցի `SESSIONINFO` աղյուսակում և քեշում։

Տե՛ս օգտագործման [օրինակ](../examples/SessionInfo.md):

```c#
public class SessionInfo
{
    public DateTime WkDate { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public int QueryTimeout { get; }
    public int DsQueryTimeout { get; }
    public string ComputerName { get; }
    public string ARMName { get; }
    public string UserName { get; }
    public short Suid { get; }
    public bool IsAdmin { get; }
    public DateTime ExpirationDate { get; }
    public string SessionGuid { get; }
    public short? ApiClientId { get; }
    public bool? FilterInSqlProfiler { get; }
}
```

* `WkDate` - Սեսսիայի բացման ամսաթիվը/ժամանակը։
* `StartDate` - "Դրույթներ" պատուհանի "Հաշվետու ժամանակաշրջան"-ի սկզբի ամսաթիվ/ժամանակը։
* `EndDate` - "Դրույթներ" պատուհանի "Հաշվետու ժամանակաշրջան"-ի սկզբի ամսաթիվ/ժամանակը։
* `QueryTimeout` - Սեսսիայի ընթացքում հարցումների կատարման առավելագույն ժամանակը վայրկյաններով։ Լռությամբ արժեքը 30 վրկ է։ Հնարավոր է փոխել ծրագրի UI-ի "Դրույթներ" պատուհանում։
* `DsQueryTimeout` - Սեսսիայի ընթացքում տվյալների աղբյուրների հարցումների կատարման առավելագույն ժամանակը վայրկյաններով։ Լռությամբ արժեքը 300 վրկ է (5 ր)։ Հնարավոր է փոխել ծրագրի UI-ի "Դրույթներ" պատուհանում։
* `ComputerName` - Մուտք գործած օգտատիրոջ համակարգչի անուն։
* `ARMName` - Մուտք գործած օգտատիրոջ լռությամբ ԱՇՏ-ն։
* `UserName` - Մուտք գործած օգտատիրոջ ներքին անուն։
* `Suid` - Մուտք գործած օգտատիրոջ ներքին համար (կոդ)։
* `ExpirationDate` - Սեսսիայի վավերականության ժամկետը։
* `SessionGuid` - Սեսսիայի ներքին նույնականացման համար (Guid):
* `ApiClientId` - Մուտք գործած կլիենտ ծրագրի ներքին նույնականացման համար (id):
* `FilterInSqlProfiler` - Սեսսիայի ընթացքում կատարված Sql հարցումների տարանջատման հայտանիշ Sql Profiler-ում։ `true` արժեքի դեպքում ընթացիկ սեսսիայի ընթացքում կատարված Sql հարցումները տարանջատվում են ուրիշ սեսսիաների կատարած հարցումներից Sql Profiler-ում։ Սեսսիայի ընթացքում կատարված Sql հարցումները Sql Profiler-ում դիտելու համար անհրաժեշտ է ստանալ "Սերվիսային հարցումների տարանջատման բանալի"-ն "Ինֆորմացիա միացումների մասին" պատուհանից։
