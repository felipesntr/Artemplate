# 📄 Gerador de PDF de Obras de Arte

Uma API em .NET que gera u, PDF a partir de um template HTML com informações sobre uma obra de arte. Utiliza `DinkToPdf` (wkhtmltopdf) para renderizar o conteúdo com suporte a imagens, fontes personalizadas e metadados.

## 🔧 Funcionalidades

- 📄 Geração de PDF com layout personalizado
- 🖼️ Imagem da obra via URL externa (convertida em base64)
- 🧠 Preenchimento automático de placeholders no HTML
- ✍️ Suporte a envio de dados dinâmicos via POST
- 🌐 Endpoint fixo de exemplo: "A Noite Estrelada"

## 🚀 Endpoints

### Gerar PDF com dados personalizados

```http
POST /api/pdf/gerar-pdf
```

**Corpo (JSON):**

```json
{
  "titulo": "Nome da obra",
  "subtitulo": "Autor · Ano",
  "urlImagem": "https://url-da-imagem.jpg",
  "descricao": "Texto descritivo da obra.",
  "biografia": "Biografia do artista.",
  "nomeArtista": "Nome completo",
  "ano": "Ano de criação",
  "tecnica": "Técnica utilizada",
  "dimensoes": "Dimensões físicas",
  "localizacao": "Museu ou galeria",
  "categorias": "Classificações ou estilos"
}
```

### Exemplo fixo

```http
GET /api/pdf/noite-estrelada
```

## 📦 Requisitos

- .NET 8
- Pacote NuGet: `DinkToPdf`
- Binário nativo do `wkhtmltopdf` (`libwkhtmltox.dll`)
- Template HTML salvo em `Assets/Templates/quadro_template.html`

## 📁 Estrutura esperada

```
/Assets/Templates/quadro_template.html
/DinkToPdf/Native/libwkhtmltox.dll
```
