---
layout: page
title: "Ինյեկցիա (Dependency Injection)" 
---

[.NET dependency injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)

## Ի՞նչ է Dependency-ն

Dependency(կախվածությունը) ծրագրավորման լեզուներում նշանակում է որ մի դաս օգտագործում է ուրիշ դաս(երի) ֆունկցիոնալությունը։

Օրինակ ունենք `OrderService` դաս, որը մշակում է պատվերները և այն պետք է օգտագործի  `PaymentService` դասը պատվերի համար անհրաժեշտ վճարման մշակման համար։ 
`OrderService` դասում `PaymentService` դասի ֆունկցիանալությունից օգտվելու համար անհրաժեշտ է ստեղծել դասի օբյեկտ ու կանչել անհրաժեշտ մեթոդները։

```c#
public class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        // some logic
        ...
    }

    public PaymentService()
    {        
    }
}

public class OrderService
{
	private readonly PaymentService paymentService;
	public OrderService()
	{
	   this.paymentService = new PaymentService();
	}
	
	public void ProcessOrder(int orderID, int paymentAmount)
	{
            this.paymentService.ProcessPayment(paymentAmount);
            // processing order
        ...
	}
}
```

Երբ որ `PaymentService` դասի կոնստրուկտորում ավելացնենք նոր պարամետր և կոդը build անենք, կստանանք սխալի հետևյալ հաղորդագրությունը **"There is no argument given that corresponds to the required formal parameter 'data"**, քանի որ փոփոխություն չենք կատարել  `OrderService` դասում և այնտեղ մնացել է արդեն գոյություն չունեցող պարամետրեր չպարունակող կոնստրուկտորը։

```c#
public class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        // some logic
        ...
    }

    public PaymentService(string someData)
    {
        //some logic
        ...
    }
}

public class OrderService
{
	private readonly PaymentService paymentService;
	public OrderService()
	{
           this.paymentService = new PaymentService();
	}
	
	public void ProcessOrder(int orderID, int paymentAmount)
	{
	   this.paymentService.ProcessPayment(paymentAmount);
           // processing order
        ...
	}
}
```
Այս օրինակը ցույց է տալիս, թե ինչպես փոփոխությունները կարող են խնդրահարույց լինել այն սցենարների համար, երբ առաջին դասը կախված է երկրորդ դասից և առաջին դասը երկրորդի ֆունկցիոնալությունից օգտելու համար պիտի ստեղծի երկրորդ դասի օբյեկտը։ 
Իրականում կախվածությունները կարող են ավելի շատ էլ լինել։

## Dependency injection

Dependency injection հնարավորություն է տալիս մի դասին օգտագործել մյուս դասի ֆունկցիոնալությունը՝ առանց մտածելու մյուս դասի օբյեկտի ստեղծման մասին։

Ստորև բերված է վերևում նկարագրված օրինակի փոփոխված տարբերակը Dependency injection մեխանիզմի օգտագործմամբ՝ չի ստեղծում `PaymentService` դասի օբյեկտ `OrderService` դասում, այլ `OrderService` դասի կոնստրուկտորում ավելացվում է  `PaymentService`  տիպի պարամետր, որի արժեքն էլ փոխանցվում `OrderService` դասում ստեղծված լոկալ փոփոխականին։

```c#
public class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        // some logic
        ...
    }

    public PaymentService(string someData)
    {
        //some logic
        ...
    }
}

public class OrderService
{
	private readonly PaymentService paymentService;
	public OrderService(PaymentService paymentService)
	{
	   this.paymentService = new PaymentService();
	}
	
	public void ProcessOrder(int orderID, int paymentAmount)
	{
	   this.paymentService.ProcessPayment(paymentAmount);
	   // processing order
        ...
	}
}
```

Իսկ `PaymentService` տիպի օբյեկտի ստեղծման համար պատասխանատու է դառնում սերվիսի կոնտեյները։ Անհրաժեշտ է ռեգիստրացնել ծրագրի աշխատանքի համար անհրաժեշտ դասերը `Startup.cs`-ում, հետո կանչել `Program.cs`-ում, որից հետո .Net-ի ներդրված կոնտեյները  (IServiceProvider) կստեղծի դասերի օբյեկտները և կտրամադրի անհրաժեշտ դասերին։

**Օրինակ** 

Startup.cs ֆայլ
```c#
using Microsoft.Extensions.DependencyInjection;

namespace ArmSoft.AS8X.TestExample
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<OrderService>();
            services.AddScoped<PaymentService>();
        }
    }
}

``` 

Program.cs ֆայլ
```c#
namespace ArmSoft.AS8X.TestExample
{
   public class Program
   {
      public static int Main(string[] args)
      {
          var builder = WebApplication.CreateBuilder(args);
	  builder.Services.ConfigureServices();
          var app = builder.Build();
          app.Run();
          return 0;
      }
   }
}
```

