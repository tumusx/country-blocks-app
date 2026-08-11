# 📐 Plano de Execução — Desafio MAUI Asaas

> Documento vivo. Cada fase entrega algo funcional e testável antes de avançar.

---

## 🎯 Requisitos do Desafio

- **Framework**: .NET MAUI 10 + C# 12+
- **API**: `restcountries.com` (real, sem mock)
- **Plataformas alvo**: iOS e/ou Android
- **Entrega**: ZIP sem `bin/obj`, prazo 3 dias corridos
- **Figma**: https://www.figma.com/design/fkQIcNQR7meeWw3hF89eTe/Desafio-t%C3%A9cnico-Asaas (senha: `jaw-cleave-raft-game`)

### Telas
1. Login
2. Home
3. Geração de Blocos (Desafio 1)
4. Busca de Países (Desafio 2)
5. Lista de Países

---

## 🏗 FASE 0 — Setup do Ambiente ✅
- [x] .NET 10 SDK (10.0.302)
- [x] Workload MAUI (10.0.20)
- [x] Xcode 26.2 selecionado (⚠️ precisa 26.6 pra iOS build)
- [x] Android SDK + platform-tools

## 📦 FASE 1 — Criação e Estrutura do Projeto ✅
- [x] `dotnet new maui -n AsaasChallenge` em `Projects/Challenges/`
- [x] Pastas MVVM: `Views/`, `ViewModels/`, `Models/`, `Services/`, `Converters/`
- [x] NuGets: `CommunityToolkit.Mvvm 8.4.2`, `CommunityToolkit.Maui 15.0.0`, `Microsoft.Extensions.Http 10.0.11`
- [x] `MauiProgram.cs` configurado com Toolkit
- [x] `MauiVersion 10.0.60` fixado no csproj
- [x] Paleta Asaas aplicada em `Colors.xaml` (#1E40F5)
- [x] Build Android OK (57s)
- [x] Rodou no emulador `Medium_Phone_API_36.0`

## 🎨 FASE 1.5 — MCP Figma ✅
- [x] Instalar `figma@claude-plugins-official` (via `/plugin`)
- [x] Autenticar (OAuth Figma)
- [x] Duplicar arquivo (senha impede MCP no original — cópia em `ax7LSivG8Qg08iitBK96SV`)
- [x] Extrair metadata + variáveis + screenshots
- [x] Paleta oficial aplicada em `Colors.xaml`
- [x] Screenshots em `docs/figma-refs/`
- [x] Tokens documentados em `docs/DESIGN_TOKENS.md`
- [ ] Exportar logo Asaas + ícone X (na hora que implementarmos as telas correspondentes)

## 📚 FASE 1.6 — MAUI Skills (davidortinau/maui-skills) ✅
Skills instaladas em `.claude/skills/` (10 selecionadas de 41):

**Essenciais** (mapeadas direto no plano):
- [x] `maui-shell-navigation` → AppShell + rotas
- [x] `maui-secure-storage` → sessão persistida
- [x] `maui-rest-api` → restcountries.com
- [x] `maui-collectionview` → lista países c/ seleção múltipla
- [x] `maui-data-binding` → bindings MVVM
- [x] `maui-dependency-injection` → registro de services

**Úteis**:
- [x] `maui-current-apis` → evitar APIs deprecadas (MAUI 10)
- [x] `ux-mobile` → padrões touch/mobile
- [x] `maui-hot-reload-diagnostics` → debug XAML
- [x] `maui-safe-area` → notch/edge-to-edge

## 🔐 FASE 2 — Login + Persistência de Sessão
- [ ] `LoginPage` + `LoginViewModel`
- [ ] `IAuthService` (simula requisição com `Task.Delay`)
- [ ] `ISessionService` usando `SecureStorage` para persistir usuário
- [ ] `AppShell` decide rota inicial: Login ou Home
- [ ] Validações de campo (usuário/senha não vazios)

## 🏠 FASE 3 — Home
- [ ] `HomePage` + `HomeViewModel`
- [ ] Exibir "Olá, {{Usuário}}" (via SessionService)
- [ ] 2 botões navegando para Desafio 1 e Desafio 2
- [ ] Versão via `AppInfo.VersionString` no rodapé
- [ ] Registrar rotas no `AppShell`

## 🧱 FASE 4 — Desafio 1: Geração de Blocos
- [ ] `BlocksPage` + `BlocksViewModel`
- [ ] Input numérico com validação
- [ ] `FlexLayout` (wrap) ou `CollectionView` com `GridItemsLayout` (Span dinâmico)
- [ ] Binding reativo: ao mudar número → regenera blocos

## 🌎 FASE 5 — Desafio 2: Busca de Países
- [ ] `CountrySearchPage` + `CountrySearchViewModel`
- [ ] 2 botões (Norte / Sul) que navegam para Lista
- [ ] `ICountryStorageService` (persistir seleção com `Preferences` ou JSON local)
- [ ] Renderizar países selecionados com botão de remover

## 📋 FASE 6 — Lista de Países + API
- [ ] `CountryListPage` + `CountryListViewModel`
- [ ] `ICountryApiService` (HttpClient → `restcountries.com/v3.1/region/{region}`)
- [ ] Modelo `Country` (nome + bandeira SVG/PNG)
- [ ] Loading spinner enquanto busca
- [ ] `CollectionView` com seleção múltipla + checkbox visual
- [ ] Botão "Finalizar" retorna com lista via query params do Shell

## ✅ FASE 7 — Polimento e Entrega
- [ ] Testar fluxo completo em Android/iOS
- [ ] Ajustar visual comparando com Figma
- [ ] Tratamento de erros (sem internet, API fora)
- [ ] Gerar ZIP **sem bin/obj**
- [ ] Enviar por email para recrutadora

---

## 🗂 Estrutura Alvo Final

```
AsaasChallenge/
├── Views/
│   ├── LoginPage.xaml
│   ├── HomePage.xaml
│   ├── BlocksPage.xaml
│   ├── CountrySearchPage.xaml
│   └── CountryListPage.xaml
├── ViewModels/
│   ├── LoginViewModel.cs
│   ├── HomeViewModel.cs
│   ├── BlocksViewModel.cs
│   ├── CountrySearchViewModel.cs
│   └── CountryListViewModel.cs
├── Models/
│   └── Country.cs
├── Services/
│   ├── IAuthService.cs / AuthService.cs
│   ├── ISessionService.cs / SessionService.cs
│   ├── ICountryApiService.cs / CountryApiService.cs
│   └── ICountryStorageService.cs / CountryStorageService.cs
├── Converters/
└── docs/
    ├── PLAN.md
    └── DECISIONS_LOG.md
```
