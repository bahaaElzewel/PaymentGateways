using PaymentGateways.Services;
using PaymentGateways.Services.Hmac;
using PaymentGateways.Services.Paymob;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(o =>
{
    o.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddScoped<IPaymentGateway, PaymobPaymentService>();
builder.Services.AddScoped<BasePaymentService>();
builder.Services.AddScoped<IAcceptHmac, AcceptHmac>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
