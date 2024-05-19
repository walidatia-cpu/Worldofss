    using CV_Manager.AutoMapper;
    using CV_Manager.Extensions;
    using CV_Manager.Filters.ActionFilter;
    using Microsoft.AspNetCore.Mvc;

    var builder = WebApplication.CreateBuilder(args);

    #region Service Collection Extensions 

    builder.Services.AddConfig(builder.Configuration);
    builder.Services.AddMyDependencyGroup();

    #endregion

    builder.Services.AddAutoMapper(typeof(MappingProfiles));


    builder.Services.Configure<ApiBehaviorOptions>(options
        => options.SuppressModelStateInvalidFilter = true);


    builder.Services.AddScoped<ValidateModelAttribute>();

    builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(ValidateModelAttribute));
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.AddGlobalErrorHandler();

    #region migrate database
    using (var scope = app.Services.CreateScope())
    {
        scope.MigrateDatabase();
    }
    #endregion

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(builder => builder
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin()
        );

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
