# 🎨 Design Tokens — Extraídos do Figma

> Extraído via MCP Figma do arquivo duplicado (`ax7LSivG8Qg08iitBK96SV`).
> Fonte original: `fkQIcNQR7meeWw3hF89eTe` (Asaas — Desafio Técnico).

---

## 🎨 Cores (Colors.xaml)

| Nome | Hex | Uso |
|---|---|---|
| **Primary** | `#0038E5` | Botões principais, header, logo, links |
| **PrimaryDark** | `#002BB5` | Estados pressed/hover do primário |
| **PrimaryUltraSoft** | `#F2F5FB` | Backgrounds sutis, cards |
| **Secondary** | `#6C757D` | Textos secundários, placeholders |
| **InfoSoft** | `#9FCBDE` | Feedback informativo |
| **Danger** | `#C5381A` | Botão X remover país (SVG circle) |
| **Success** | `#2FBF71` | Feedback positivo (fallback) |
| **AppBackground** | `#FFFFFF` | Fundo principal do app |
| **InputBorder** | `#E0E0E0` | Bordas de inputs e cards de lista |
| **TextPrimary** | `#212121` | Texto principal (Open Sans) |
| **TextSecondary** | `#6C757D` | Texto secundário |
| **PlaceholderText** | `#9CA3AF` | Placeholders de input |

---

## 📐 Espaçamentos e dimensões

| Token | Valor |
|---|---|
| Tela padrão | 360 × 640 (mobile portrait) |
| Header height | 56 |
| Padding lateral | 16 |
| Botão altura | 56 |
| Botão border-radius | ~28 (pill-shape) |
| Input altura | 56 |
| Input border-radius | 8 |
| Card lista border-radius | 16 |
| Card lista padding | 16 |
| Bloco (grid) | 70 × 48 |
| Gap entre blocos | 16 |
| Gap entre linhas de blocos | 16 |
| Ícone padrão | 24 × 24 |

---

## 🔤 Tipografia

| Uso | Font | Size | Weight |
|---|---|---|---|
| Título "Ola, {{ Usuário }}" | Open Sans | 20-24 | Bold |
| Botão | Open Sans | 16 | Semibold |
| Input placeholder | Open Sans | 16 | Regular |
| Item lista | Open Sans | 16 | Regular |
| Rodapé "Versão 1.0.0" | Open Sans | 12-14 | Semibold |
| Header label (branco) | Open Sans | 16 | Semibold |

**Fonte principal**: Open Sans (Regular + Semibold já incluídos no template MAUI)

---

## 📱 Telas mapeadas (nodeIds do Figma)

| Tela | nodeId | Screenshot |
|---|---|---|
| Login (Stand by) | `1:207` | `figma-refs/01-login.png` |
| Home (Stand by com 2 botões) | `1:346` | `figma-refs/02-home.png` |
| Blocos — 8 blocos (variante Stand by) | `1:180` | `figma-refs/03-blocks-8.png` |
| Blocos — 3 blocos (Resultado) | `1:216` | — |
| Blocos — 8 blocos (Botões) | `1:232` | — |
| Busca Países — Botões | `1:259` | `figma-refs/04-country-search-buttons.png` |
| Busca Países — Retorno da busca | `1:331` | `figma-refs/07-country-search-selected.png` |
| Lista de países | `1:281` | `figma-refs/05-country-list.png` |
| Versão do app | `1:301` | — |
| Loading | `1:273` | `figma-refs/06-loading.png` |

---

## 🖼 Assets a exportar do Figma

- [ ] `img_asaas_logo` (nodeId `1:214`, 124×36) — logo da tela de Login
- [ ] `icons/x-filled` (nodeId `1:288`, 24×24) — SVG do X vermelho na lista
- [ ] Ícone de seta voltar do header — provavelmente componente do sistema

---

## 🔑 Variáveis Figma originais (nomenclatura tokens)

Namespace `atlas/color/...`:
- `surface/interaction/primary/ultra-soft/active` → `#0038E5`
- `surface/static/container/primary/hard` → `#0038E5`
- `surface/static/container/primary/ultra-soft` → `#F2F5FB`
- `icon/interaction/primary/ultra-soft/active` → `#0038E5`

Namespace `Global/`:
- `Secondary/500` → `#6C757D`
- `Feedback/Info/200` → `#9FCBDE`
