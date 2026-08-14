# Country Blocks App

[![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![MAUI](https://img.shields.io/badge/MAUI-10.0.60-0038E5)](https://learn.microsoft.com/dotnet/maui/)
[![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp)](https://learn.microsoft.com/dotnet/csharp/)
[![Android](https://img.shields.io/badge/Android-tested-3DDC84?logo=android)](https://developer.android.com/)

---

## 📱 Sobre

Aplicativo mobile que implementa 5 fluxos principais:

1. **Login** com sessão persistente (`SecureStorage`)
2. **Home** com nome do usuário e navegação para os desafios
3. **Geração dinâmica de blocos** — input reativo que renderiza N blocos em tempo real
4. **Busca de países** por região (América do Norte/Sul) via RestCountries
5. **Lista de países** com seleção múltipla, bandeiras e persistência

Documento completo de arquitetura + decisões técnicas: [`docs/PITCH.md`](docs/PITCH.md)

---

## 🛠 Stack

| Camada | Tecnologia |
|---|---|
| Framework | .NET MAUI 10.0.60 |
| Linguagem | C# 12 |
| MVVM | CommunityToolkit.Mvvm 8.4.2 (source generators) |
| UI Toolkit | CommunityToolkit.Maui 15.0.0 |
| HTTP | `IHttpClientFactory` + `System.Net.Http.Json` |
| API | [RestCountries v5](https://restcountries.com/) |
| Sessão | `SecureStorage` (Keystore Android / Keychain iOS) |
| Seleções | `Preferences` + `System.Text.Json` |
| Navegação | Shell + `[QueryProperty]` |

---

## 🏗 Arquitetura

```
Views (XAML)
    ↓ BindingContext + Commands
ViewModels (ObservableObject)
    ↓ depende de abstrações (interfaces)
Services (IAuthService, ISessionService, ICountryApiService, ICountryStorageService)
    ↓
Externo (RestCountries API, SecureStorage, Preferences)
```

**3 regras invioláveis:**
1. View nunca fala com Service — sempre via ViewModel
2. ViewModel nunca instancia Service concreto — recebe interface via DI
3. Service não conhece View nem ViewModel — retorna DTOs/Models puros

Diagramas detalhados (fluxograma + sequences + state machine) em [`docs/PITCH.md`](docs/PITCH.md).

---

## 🚀 Como rodar

### Pré-requisitos

- .NET SDK 10.0.302+
- Workload MAUI: `sudo dotnet workload install maui`
- **Android:** Android SDK + emulador (testado em API 36)
- **iOS:** Xcode 26.6+ (não testado neste ambiente)

### Setup

```bash
git clone https://github.com/tumusx/country-blocks-app.git
cd country-blocks-app

# 1. Configure sua chave da RestCountries
cp Secrets.cs.example Secrets.cs
# edite Secrets.cs e cole sua chave (obtenha em https://restcountries.com/)

# 2. Restore + build
dotnet restore
dotnet build -f net10.0-android

# 3. Rode no emulador Android
dotnet build -t:Run -f net10.0-android
```

> **⚠️ Importante:** `Secrets.cs` é gitignored por conter credenciais. Nunca commite este arquivo.

---

## 📁 Estrutura

```
├── Models/
│   └── Country.cs                    # Id, Name, FlagUrl, IsSelected
├── Services/                         # Interfaces + implementações
│   ├── IAuthService.cs / AuthService.cs
│   ├── ISessionService.cs / SessionService.cs
│   ├── ICountryApiService.cs / CountryApiService.cs
│   └── ICountryStorageService.cs / CountryStorageService.cs
├── ViewModels/
│   ├── LoginViewModel.cs
│   ├── HomeViewModel.cs
│   ├── BlocksViewModel.cs
│   ├── CountrySearchViewModel.cs
│   └── CountryListViewModel.cs
├── Views/                            # XAML + code-behind
├── Resources/
│   ├── Fonts/    (OpenSans)
│   ├── Images/   (ícones)
│   └── Styles/   (tokens do Figma)
├── docs/
│   ├── PITCH.md                      # Pitch técnico completo (com diagramas)
│   ├── DECISIONS_LOG.md              # Log de decisões técnicas
│   ├── PLAN.md                       # Plano de implementação
│   └── REGRAS_NEGOCIO.md             # Regras de negócio
├── Secrets.cs.example                # Template de credenciais
├── App.xaml + .cs                    # Startup
├── AppShell.xaml + .cs               # Rotas Shell
└── MauiProgram.cs                    # DI container
```

## 📄 Documentação

- **[docs/PITCH.md](docs/PITCH.md)** — Pitch técnico completo com diagramas de arquitetura
- **[docs/DECISIONS_LOG.md](docs/DECISIONS_LOG.md)** — Log cronológico de decisões
- **[docs/PLAN.md](docs/PLAN.md)** — Plano de execução por fases

---
