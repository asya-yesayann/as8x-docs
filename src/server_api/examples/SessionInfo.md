---
layout: page
title: "Օրինակ SessionInfo, SUID, UserID, QueryTimeout, IsAdmin, WkDate"
---

ISessionInfoService, GetInfo, DsQueryTimeout օգտագործման օրինակներ։

Օրինակում օգտագործվում են ընթացիկ օգտագործողի սեսսիայի տվյալները։

Օրինակում ստեղծվում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand) դասի օբյեկտ՝ [IDBService](../services/IDBService.md) դասի [CreateCommand](../services/IDBService.md#createcommand) մեթոդի միջոցով` Sql հարցումներ կատարելու համար։

Որպես հարցման կատարման առավելագույն ժամանակ դրվում է սեսսիայի `QueryTimeout` հատկության արժեքը և սեսսիայի տվյալների որոշ մասը գրանցվում է տվյալների պահոցում։ 

```c#
public async Task WriteLog(string operationCode, string comment)
{
    var sessionInfo = this.sessionInfoService.GetInfo();

    var userId = sessionInfo.Suid;                      //ընթացիկ օգտագործողի կոդը
    var userComputerName = sessionInfo.ComputerName;    //ընթացիկ օգտագործողի համակարգչի անունը
    var currentDate = sessionInfo.WkDate;               //ընթացիկ ամսաթիվը ընթացիկ օգտագործողի դրույթներից

    if (!sessionInfo.IsAdmin)
    {
        throw new Exception("Լոգ գրանցելու իրավասություն չունեք։".ToArmenianANSI());
    }

    using var cmd = this.DbService.CreateCommand();
    cmd.CommandTimeout = sessionInfo.QueryTimeout;    //հարցման կատարման մաքսիմալ ժամանակը ընթացիկ օգտագործողի դրույթներից

    cmd.CommandText = """
        insert into APPLOG (fDATE, fSUID, fCOMMENT, fOPERCODE, fCOMPNAME, fAPICLIENTID)
                    values (@DATE, @SUID, @COMMENT, @OPERCODE, @COMPUTERNAME, @APICLIENTID)
        """;

    cmd.Parameters.Add("@SUID", SqlDbType.SmallInt).Value = userId;
    cmd.Parameters.Add("@COMPUTERNAME", SqlDbType.VarChar, APPLOG.fCOMPNAMELength).Value = userComputerName;
    cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = currentDate;
    cmd.Parameters.Add("@APICLIENTID", SqlDbType.SmallInt).Value = sessionInfo.ApiClientId;
    cmd.Parameters.Add("@COMMENT", SqlDbType.VarChar, APPLOG.fCOMMENTLength).Value = comment;
    cmd.Parameters.Add("@OPERCODE", SqlDbType.Char, APPLOG.fOPERCODELength).Value = operationCode;
            
    await cmd.ExecuteNonQueryAsync();
}
```
