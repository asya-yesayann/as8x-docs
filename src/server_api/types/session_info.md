---
layout: page
title: "SessionInfo" 
---

Ծրագիր մուտք գործելիս բացվում է սեսսիա, որը պարունակում է մուտք գործած օգտատիրոջ տվյալները և ծրագրի աշխատանքի որոշ կարգավորումներ: Սեսսիան ավտոմատ կերպով փակվում է ծրագրից դուրս գալիս։

Սեսսիայի փակման հետ համատեղ հեռացվում են նաև սեսսիայի ընթացքում առաջացած ժամանակավոր ֆայլերը, ընդհատվում ընթացիկ job-երը։

Սեսսիայի մասին ինֆորմացիան պահվում է տվյալների պահոցի `SESSIONINFO` աղյուսակում և քեշում։

public class SessionInfo
{
    public DateTime WkDate { get; internal set; }
    public DateTime StartDate { get; internal set; }
    public DateTime EndDate { get; internal set; }
    public int QueryTimeout { get; internal set; }
    public int DsQueryTimeout { get; internal set; }
    public string ComputerName { get; internal set; }
    public string ARMName { get; internal set; }
    public string UserName { get; private set; }
    public short Suid { get; private set; }
    public bool IsAdmin { get; private set; }
    public DateTime ExpirationDate { get; internal set; }
    public string SessionGuid { get; internal set; }
    public short? ApiClientId { get; internal set; }
    public bool? FilterInSqlProfiler { get; internal set; }
}

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
