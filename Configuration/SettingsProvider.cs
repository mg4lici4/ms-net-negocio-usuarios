using System;

namespace UsuariosApi.Configuration;

public class SettingsProvider
{
    private readonly IConfiguration _configuration;
    private readonly AppSettings _appSettings;

    public SettingsProvider(IConfiguration configuration)
    {
        _configuration = configuration;
        _appSettings = new AppSettings();
        _configuration.GetSection("ParametrosGenerales").Bind(_appSettings);
    }

    // public string UrlServicio => _appSettings.UrlServicio;
    // public int TiempoEsperaSegundos => _appSettings.TiempoEsperaSegundos;
    // public bool ModoDebug => _appSettings.ModoDebug;

    public string DefaultConnectionString =>
        _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
}