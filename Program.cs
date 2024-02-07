using System;
using System.IO;
using RestaurantBookingApi;

    
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    CryptographyService _cryptoService = new CryptographyService();
    app.MapGet("/", () => "/encrypt for encryption and /decrypt for decrypt\nSyntax: /[endpoint]?input='[string]'\n[IMPORTANT]--> Key must be larger than 0 and smaller than 27");
    app.MapGet("/encrypt", (string input) => _cryptoService.Encrypt(input));
    app.MapGet("/decrypt", (string input) => _cryptoService.Decrypt(input));         
    app.Run();

