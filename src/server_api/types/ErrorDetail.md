---
layout: page
title: "ErrorDetail" 
---

Այս դասը նախատեսված է ծրագրի աշխատանքի ընթացքում առաջացող սխալների նկարագրման համար։

Օգտագործվում է [IErrorHandlingService](../services/IErrorHandlingService.md).[GetSqlExceptionDetails](../services/IErrorHandlingService.md#getsqlexceptiondetails) մեթոդում։

```c#
public class ErrorDetail
{
    public string Message { get; set; }
    public int Number { get; set; }

    public ErrorDetail(string message, int number = -1)
    {
        this.Message = message;
        this.Number = number;
    }
}
```

* `Message` - Սխալի հաղորդագրությունը։
* `Number` - Սխալի համարը։

