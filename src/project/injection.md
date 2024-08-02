---
layout: page
title: "Ինյեկցիա (Dependency Injection)" 
---

[.NET dependency injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)

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

