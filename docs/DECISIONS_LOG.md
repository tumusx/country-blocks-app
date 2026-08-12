# 📔 Decisões Técnicas & Log de Sessão

> Registro cronológico de decisões, escolhas de stack e eventos relevantes.

---

## 🛠 Stack Definitiva

| Camada | Escolha | Versão | Motivo |
|---|---|---|---|
| Framework | .NET MAUI | 10.0.60 | Requisito do desafio |
| SDK | .NET | 10.0.302 | Última stable |
| Linguagem | C# | 12+ | Requisito do desafio |
| MVVM | CommunityToolkit.Mvvm | 8.4.2 | `[ObservableProperty]`, `[RelayCommand]` (source generators) |
| UI Toolkit | CommunityToolkit.Maui | 15.0.0 | Behaviors, Converters, Snackbar |
| HTTP | Microsoft.Extensions.Http | 10.0.11 | `IHttpClientFactory` + DI |
| API | restcountries.com v3.1 | — | Requisito do desafio |
| Persistência | `SecureStorage` + `Preferences` | MAUI Essentials | Nativo, sem NuGet extra |
| MCP Design | Figma Remote MCP | plugin oficial | Extrair specs do Figma |

---

## 🎨 Paleta (Colors.xaml — atualizada com tokens reais do Figma)

```
Primary:        #0038E5   (Azul Asaas oficial — extraído do Figma)
PrimaryDark:    #002BB5
PrimaryUltraSoft: #F2F5FB
Secondary:      #6C757D
InfoSoft:       #9FCBDE
Danger:         #C5381A   (extraído do SVG do X-filled)
Success:        #2FBF71
AppBackground:  #FFFFFF
InputBorder:    #E0E0E0
TextPrimary:    #212121
TextSecondary:  #6C757D
PlaceholderText:#9CA3AF
```

Ver `docs/DESIGN_TOKENS.md` para tabela completa (espaçamentos, tipografia, screenshots).

---

## 📁 Localização

- Projeto: `/Users/murilloalvesdasilva/Projects/Challenges/AsaasChallenge/`
- Emulador Android: `Medium_Phone_API_36.0`
- Package name: `com.companyname.asaaschallenge`

---

## 📜 Log de Sessão (2026-08-11)

### Setup Inicial
- ✅ Verificado ambiente: Xcode 26.2, Android SDK, Homebrew
- ✅ Instalado .NET SDK 10.0.302 via brew cask
- ✅ Corrigido `xcode-select` para apontar Xcode-26.2.0.app
- ✅ Instalado workload MAUI (via `sudo dotnet workload install maui`)
- ⚠️ Ajustado permissão de `~/.local/share/NuGet` (chown para usuário)

### Criação do Projeto
- ✅ `dotnet new maui -n AsaasChallenge` em `Projects/Challenges/`
- ✅ Criadas pastas MVVM: `Views/`, `ViewModels/`, `Models/`, `Services/`, `Converters/`
- ✅ Adicionados 3 NuGets principais
- ⚠️ Conflito de versão: CommunityToolkit.Maui 15.0.0 requer Maui.Controls ≥ 10.0.60 → fixado `MauiVersion 10.0.60` no csproj
- ✅ Adicionado `.UseMauiCommunityToolkit()` no `MauiProgram.cs`
- ✅ Sobrescrita paleta padrão MAUI (roxo `#512BD4`) pela paleta Asaas azul

### Builds
- ✅ Android build OK (57s)
- ❌ iOS build falhou: requer Xcode 26.6, temos 26.2
- ✅ App deployado e lançado no emulador via `adb shell monkey`

### Decisões
- **Foco em Android primeiro**: iOS bloqueado pela versão do Xcode. Desafio aceita apenas uma plataforma como mínimo.
- **MVVM com CommunityToolkit**: menos boilerplate que INotifyPropertyChanged manual.
- **SecureStorage para sessão**: usuário logado é sensível o suficiente pra não ficar em Preferences plain.
- **Preferences para países selecionados**: dados não sensíveis, JSON serializado.
- **MCP Figma**: usar plugin oficial remoto (não Enterprise-only Desktop version).
- **MAUI Skills copiadas para projeto** (`.claude/skills/`, não instaladas globalmente): mantém o projeto autocontido e versionável. Escolhidas 10 de 41 skills do repo `davidortinau/maui-skills`. Skills carregam automaticamente quando o Claude Code detecta contexto relevante.

### MCP Figma
- **File original**: `fkQIcNQR7meeWw3hF89eTe` (compartilhado por senha — MCP não acessa)
- **File duplicado** (usado pelo MCP): `ax7LSivG8Qg08iitBK96SV` (na conta `mugrillo1456@gmail.com`)
- **Plugin**: `figma@claude-plugins-official` (marketplace `anthropics/claude-plugins-official`)
- **Tools disponíveis**: `get_metadata`, `get_design_context`, `get_screenshot`, `get_variable_defs`, etc.
- **Fluxo**: metadata → screenshot pra referência visual → design_context de node específico quando for implementar

### Skills instaladas (10)
| Skill | Arquivos | Uso no projeto |
|---|---|---|
| maui-shell-navigation | SKILL.md + references | AppShell + rotas |
| maui-secure-storage | SKILL.md + references | Persistir sessão |
| maui-rest-api | SKILL.md + references | Consumo restcountries.com |
| maui-collectionview | SKILL.md + references | Lista países |
| maui-data-binding | SKILL.md + references | Bindings MVVM |
| maui-dependency-injection | SKILL.md + references | Services no MauiProgram |
| maui-current-apis | SKILL.md | Evitar APIs deprecadas |
| ux-mobile | SKILL.md | Padrões UX touch |
| maui-hot-reload-diagnostics | SKILL.md + refs + scripts | Debug XAML |
| maui-safe-area | SKILL.md + references | Notch/edge-to-edge |

---

### UI Scaffold (todas as 5 telas)
- ✅ Todas as 5 telas criadas (LoginPage, HomePage, BlocksPage, CountrySearchPage, CountryListPage)
- ✅ 5 ViewModels criados com `[ObservableProperty]`/`[RelayCommand]` — **todos os handlers lançam `NotImplementedException`** (usuário implementa a lógica)
- ✅ 4 services (Auth, Session, CountryApi, CountryStorage) com interfaces + impls stub
- ✅ Model `Country` (Name, FlagUrl, Region, IsSelected)
- ✅ DI configurada em `MauiProgram.cs`: services (Singleton), VMs+Views (Transient), `HttpClient` com `BaseAddress` restcountries.com/v3.1
- ✅ AppShell: `LoginPage` como raiz + rotas registradas via `Routing.RegisterRoute`
- ✅ Styles compartilhados em `Styles.xaml`: `PrimaryButton` (56h, radius 16, primary), `InputBorder` (56h, border #E0E0E0, radius 16), `HeaderBar` (56h, primary bg), `Block` (70x48, radius 8), etc.
- ✅ `InvertedBoolConverter` do CommunityToolkit registrado em `App.xaml`
- ✅ `MainPage.xaml/.cs` do template removidos
- ✅ Build: **0 erros, 0 warnings** em 30s (`dotnet build -f net10.0-android --no-incremental`)

### Decisões UI
- **Login sem Shell NavBar** (`Shell.NavBarIsVisible="False"`) — Figma mostra logo customizado
- **Header próprio** nas outras telas (Grid com bg Primary, back arrow + title) em vez de Shell NavBar — assim controlamos 100% do visual do Figma
- **CollectionView com GridItemsLayout Span=4** para blocos (substituiu FlexLayout wrap) — grid uniforme, sem gaps horizontais desalinhados
- **CollectionView com TapGestureRecognizer** no CountryListPage — em vez de SelectionMode=Multiple do CV, pra manter o visual do X-filled quando IsSelected
- **RelativeSource AncestorType** pra bind commands do VM dentro do DataTemplate (padrão MAUI moderno)
- **QueryProperty(region)** no CountryListViewModel — recebe região via query string do Shell (`GoToAsync("CountryListPage?region=south")`)

---

### Polimento Visual (segunda passada — pixel-close ao Figma)
- ✅ Reescritos os 5 XAMLs para bater com Figma (spacing, radius, shadows, tipografia)
- ✅ SVGs próprios criados em `Resources/Images/`: `back_arrow.svg` (branco), `x_circle.svg` (#C5381A com X branco), `spinner.svg`
- ✅ Removida underline padrão do Material Design nos `Entry` Android via `EntryHandler.Mapper.AppendToMapping("NoUnderline", ...)` no `MauiProgram.cs` (BackgroundTintList transparente no Android, BorderStyle=None no iOS)
- ✅ Styles refinados em `Styles.xaml`: `PrimaryButton` (56h, radius 14, shadow), `InputBorder` (radius 12), `Block` (radius 8 com shadow), `LogoWordmark` (fallback "ASAAS" 34pt bold caso não haja logo)
- ✅ Fix `Colors.xaml`: removida `TertiaryBrush` órfã (crash XamlParse); adicionadas `PrimaryDarkText`/`SecondaryDarkText` (referenciadas pelo template default do MAUI)
- ✅ Preview no emulador de todas as 5 telas via swap temporário do `AppShell` root + seed dos VMs (revertido no fim)

### Decisões de Preview
- **Seed temporário nos VMs** (`Blocks = { 1..8 }`, `SelectedCountries = { Argentina, Brasil, Paraguai }`, `Countries = { 10 países }`) apenas para screenshot — revertido para `new()` vazio no fim da sessão
- **`try/catch NotImplementedException`** no `OnAppearing` dos 3 code-behinds (Home/CountrySearch/CountryList) — permite preview sem crash mesmo com handlers stub
- **`dotnet build -t:Install`** obrigatório após `adb uninstall` — instalação via `adb install` do APK deixa runtime Mono sem `Fast Deploy` sync (`No assemblies found... Exiting...`)

---

## ❓ Pendências / Riscos

- [ ] Atualizar Xcode para 26.6 pra habilitar build iOS
- [ ] Instalar plugin Figma MCP e autenticar
- [ ] Confirmar se `restcountries.com` retorna bandeiras como URL ou base64 (impacta modelo)
- [ ] Definir se navegação usa Shell routes com query params ou passagem via constructor injection
