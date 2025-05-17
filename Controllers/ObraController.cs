using Artemplate.Dto;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Artemplate.Controllers
{
    [ApiController]
    [Route("api/v1/obra")]
    public class ObraController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConverter _converter;

        public ObraController(IConverter converter, IWebHostEnvironment env)
        {
            _env = env;
            _converter = converter;
        }

        [HttpGet("nascimento-de-venus")]
        public async Task<IActionResult> GetNascimentoDeVenusHtmlAsync()
        {
            var request = new ObraRequest
            {
                Titulo = "O Nascimento de V�nus",
                Subtitulo = "Sandro Botticelli � c. 1485",
                UrlImagem = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg/1920px-Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg",
                Descricao = "O Nascimento de V�nus � uma das obras mais emblem�ticas do Renascimento italiano. Pintada por Sandro Botticelli por volta de 1485, retrata a deusa romana emergindo do mar sobre uma concha, sendo recebida por uma das Horas, deidades que representam as esta��es. A pintura � celebrada pela eleg�ncia linear e pela idealiza��o da forma humana, representando a beleza divina e a mitologia cl�ssica. V�nus, com sua express�o serena e corpo gracioso, simboliza tanto o amor espiritual quanto o f�sico.",
                Biografia = "Sandro Botticelli (c. 1445�1510) foi um dos principais pintores do Renascimento italiano. Ativo em Floren�a, Botticelli era conhecido por suas obras que combinavam eleg�ncia formal com narrativas mitol�gicas e religiosas. Trabalhou sob o patroc�nio da poderosa fam�lia M�dici e deixou um legado art�stico que influenciou gera��es futuras. Seu estilo refinado e po�tico � reconhecido por sua delicadeza e riqueza simb�lica.",
                NomeArtista = "Sandro Botticelli",
                Ano = "c. 1485",
                Tecnica = "T�mpera sobre tela",
                Dimensoes = "172.5 cm � 278.9 cm",
                Localizacao = "Galeria Uffizi, Floren�a",
                Categorias = "Renascimento, Mitologia, Arte cl�ssica"
            };

            return await GerarPdfObraAsync(request);
        }

        [HttpGet("mona-lisa")]
        public async Task<IActionResult> GetMonaLisaHtmlAsync()
        {
            var request = new ObraRequest
            {
                Titulo = "Mona Lisa",
                Subtitulo = "Leonardo da Vinci � c. 1503�1506",
                UrlImagem = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg/330px-Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg",
                Descricao = "A Mona Lisa, pintada por Leonardo da Vinci entre 1503 e 1506, � considerada a pintura mais famosa do mundo. A obra retrata uma mulher com um sorriso enigm�tico, vestida de forma modesta e posicionada diante de uma paisagem idealizada. O uso do sfumato � t�cnica que suaviza as transi��es de cor e luz � confere � figura uma aura et�rea e misteriosa. A identidade da modelo � amplamente aceita como sendo Lisa Gherardini, esposa de um comerciante florentino. Sua express�o amb�gua, combinada com a habilidade t�cnica de Da Vinci, transformou a obra em um s�mbolo de perfei��o art�stica e um enigma que fascina estudiosos at� hoje.",
                Biografia = "Leonardo da Vinci (1452�1519) foi um dos maiores g�nios do Renascimento, atuando como pintor, engenheiro, cientista, inventor e anatomista. Conhecido por sua incans�vel curiosidade e esp�rito vision�rio, deixou um legado que vai muito al�m da arte. Suas contribui��es � ci�ncia, engenharia e medicina foram documentadas em milhares de p�ginas de cadernos. Como pintor, � reconhecido por obras como A �ltima Ceia e a pr�pria Mona Lisa, nas quais combinou observa��o aguda com inova��o t�cnica.",
                NomeArtista = "Leonardo da Vinci",
                Ano = "c. 1503�1506",
                Tecnica = "�leo sobre madeira",
                Dimensoes = "77 cm x 53 cm",
                Localizacao = "Museu do Louvre, Paris",
                Categorias = "Renascimento, Retrato"
            };

            return await GerarPdfObraAsync(request);
        }

        [HttpGet("guernica")]
        public async Task<IActionResult> GetGuernicaHtmlAsync()
        {
            var request = new ObraRequest
            {
                Titulo = "Guernica",
                Subtitulo = "Pablo Picasso � 1937",
                UrlImagem = "https://upload.wikimedia.org/wikipedia/en/7/74/PicassoGuernica.jpg",
                Descricao = "Guernica � uma das mais poderosas obras de protesto contra a guerra j� criadas. Pintada por Pablo Picasso em resposta ao bombardeio da cidade de Guernica, no Pa�s Basco, durante a Guerra Civil Espanhola, a obra utiliza uma paleta monocrom�tica em preto, branco e cinza para retratar o sofrimento humano e animal causado pelo conflito. Com figuras distorcidas e s�mbolos como o touro, o cavalo ferido e a mulher com uma l�mpada, Picasso construiu uma alegoria visual angustiante da viol�ncia, da dor e da desesperan�a provocadas pela guerra moderna.",
                Biografia = "Pablo Picasso (1881�1973) foi um pintor e escultor espanhol, cofundador do movimento cubista e um dos artistas mais influentes do s�culo XX. Inovador incans�vel, Picasso explorou diversos estilos ao longo de sua carreira, como o per�odo azul, rosa, cubismo e surrealismo. Produziu mais de 20.000 obras, incluindo pinturas, esculturas, cer�micas e gravuras. 'Guernica' � uma de suas obras mais politicamente engajadas, tendo se tornado um s�mbolo universal da paz.",
                NomeArtista = "Pablo Picasso",
                Ano = "1937",
                Tecnica = "�leo sobre tela",
                Dimensoes = "349 cm � 776 cm",
                Localizacao = "Museu Reina Sof�a, Madri",
                Categorias = "Cubismo, Arte pol�tica, Antiguerra"
            };

            return await GerarPdfObraAsync(request);
        }

        [HttpGet("noite-estrelada")]
        public async Task<IActionResult> GetNoiteEstreladaHtmlAsync()
        {
            var request = new ObraRequest
            {
                Titulo = "A Noite Estrelada",
                Subtitulo = "Vincent van Gogh � 1889",
                UrlImagem = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg/330px-Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg",
                Descricao = "A Noite Estrelada, pintada por Vincent van Gogh em junho de 1889, � uma das obras mais ic�nicas da hist�ria da arte ocidental. Criada enquanto o artista estava internado no asilo de Saint-Paul-de-Mausole, na vila de Saint-R�my-de-Provence, no sul da Fran�a, a obra n�o representa uma paisagem real observada diretamente, mas sim uma constru��o imaginada e simb�lica. Com um c�u turbulento dominado por espirais vibrantes, estrelas reluzentes e uma lua intensamente iluminada, Van Gogh traduz visualmente suas emo��es e sua percep��o espiritual do mundo. A vila retratada, embora inspirada em Saint-R�my, foi modificada com elementos fict�cios, como a igreja central de arquitetura n�rdica, que evoca mem�rias de sua inf�ncia na Holanda. A pintura � frequentemente interpretada como uma express�o do conflito interno do artista, entre a serenidade da natureza e o caos da mente.",
                Biografia = "Vincent Willem van Gogh (1853�1890) foi um pintor p�s-impressionista holand�s cuja vida e obra exerceram uma profunda influ�ncia sobre a arte do s�culo XX. Inicialmente, trabalhou como pastor e mission�rio antes de se dedicar � pintura aos 27 anos. Embora tenha produzido mais de 2.000 obras em pouco mais de uma d�cada � incluindo cerca de 860 pinturas a �leo � Van Gogh vendeu apenas uma pintura em vida. Suas obras s�o marcadas pelo uso expressivo da cor, pinceladas intensas e composi��es emotivas que romperam com o naturalismo tradicional. Durante sua vida, enfrentou severas crises de sa�de mental, incluindo epis�dios psic�ticos e depress�o profunda, o que o levou a per�odos de interna��o. Em 1890, morreu aos 37 anos em Auvers-sur-Oise, Fran�a, devido a um ferimento por arma de fogo, possivelmente autoinfligido. Ap�s sua morte, Van Gogh foi amplamente reconhecido como um dos maiores g�nios art�sticos da hist�ria moderna, sendo suas obras hoje exibidas nas mais prestigiadas cole��es de arte do mundo.",
                NomeArtista = "Vincent van Gogh",
                Ano = "1889",
                Tecnica = "�leo sobre tela",
                Dimensoes = "73.7 cm x 92.1 cm",
                Localizacao = "MoMA, Nova York",
                Categorias = "P�s-impressionismo, Paisagem, C�u noturno"
            };

            return await GerarPdfObraAsync(request);
        }

        [HttpPost("gerar-pdf")]
        public async Task<IActionResult> GerarPdfObraAsync([FromBody] ObraRequest request)
        {
            var templatePath = Path.Combine(_env.ContentRootPath, "Assets", "Templates", "quadro_template.html");
            var htmlContent = System.IO.File.ReadAllText(templatePath);

            using var httpClient = new HttpClient();
            var imageBytes = await httpClient.GetByteArrayAsync(new Uri(request.UrlImagem));
            var base64 = Convert.ToBase64String(imageBytes);
            var dataUri = $"data:image/jpeg;base64,{base64}";

            htmlContent = htmlContent
                .Replace("{{titulo}}", request.Titulo ?? "")
                .Replace("{{subtitulo}}", request.Subtitulo ?? "")
                .Replace("{{url_imagem}}", dataUri)
                .Replace("{{descricao}}", request.Descricao ?? "")
                .Replace("{{biografia}}", request.Biografia ?? "")
                .Replace("{{nome_artista}}", request.NomeArtista ?? "")
                .Replace("{{ano}}", request.Ano ?? "")
                .Replace("{{tecnica}}", request.Tecnica ?? "")
                .Replace("{{dimensoes}}", request.Dimensoes ?? "")
                .Replace("{{localizacao}}", request.Localizacao ?? "")
                .Replace("{{categorias}}", request.Categorias ?? "");

            var doc = new HtmlToPdfDocument
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Landscape,
                },
                Objects = {
                    new ObjectSettings
                    {
                        HtmlContent = htmlContent,
                        WebSettings = new WebSettings
                        {
                            DefaultEncoding = "utf-8",
                            LoadImages = true
                        }
                    }
                }
            };

            var pdf = _converter.Convert(doc);
            return File(pdf, "application/pdf", $"{request.Titulo}.pdf");
        }
    }
}
