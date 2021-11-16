﻿// <auto-generated />
using System;
using Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data_Access_Layer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211115133438_AddedMovieComments")]
    partial class AddedMovieComments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data_Access_Layer.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Тестовый комментарий",
                            MovieId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Model.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardHolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cvc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expiry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CreditCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardHolderName = "KIRYL KVIT",
                            Cvc = "522",
                            Expiry = "04/22",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636633366/CreditCardImages/visa_qkcnbw.png",
                            Number = "4556933079048353",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Model.Faq", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faqs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "Система прав на фильмы и сериалы устроена очень сложно — гораздо сложнее, чем, например, на музыку.\r\n\r\nПрава приобретаются на определенное время и на конкретную территорию (страну).\r\n\r\nНа один и тот же фильм или сериал есть разные виды прав: публичный показ (прокат в кинотеатрах), покупка фильма навсегда, аренда, просмотр по подписке, показ по рекламной модели и т. д. Больше всего денег правообладатель и производитель зарабатывают на показе фильма в кинотеатре, меньше всего — на бесплатном показе с рекламой. Именно поэтому, как правило, сначала фильм выходит в прокат. После окончания проката он появляется на видеосервисах, где его можно купить или взять в аренду. А еще через некоторое время он переходит в подписку.\r\n\r\nЕсли фильм пользуется популярностью и его продолжают покупать, то правообладатель может решить пока не продавать подписные права. Либо устанавливает такую цену за эти права, которые бы компенсировали ему деньги от распространения фильма по модели покупки.\r\n\r\nПри этом каждый новый фильм или сериал — это зачастую отдельные договоренности с правообладателем. Иногда стоимость подписных прав на фильм так высока, что мы понимаем: мы не сможем сохранить текущую стоимость нашей подписки Плюс (199 рублей в месяц) и включить в нее этот фильм.\r\n\r\nТе фильмы и сериалы, которые мы не смогли включить в подписку, остаются в Магазине. Вы можете купить их отдельно или взять в аренду и получить кешбэк, который потом можно потратить на что-то еще в Магазине или в других сервисах Плюса.",
                            Question = "Почему не все фильмы и сериалы доступны на КиноПоиске по подписке?"
                        },
                        new
                        {
                            Id = 2,
                            Answer = "На КиноПоиске есть и более дорогие подписки. Например, Плюс с more.tv — за 399 рублей в месяц вы сможете смотреть их оригинальные и эксклюзивные проекты: от Happy End и «Регби» до «Великой» и «Рассказа служанки». А если оформите Плюс Мульти с Амедиатекой (699 рублей в месяц), получите доступ к контенту more.tv и свежим хитам и классике HBO и Showtime: «Миллиардам», «Воспитанным волками», «Сценам из супружеской жизни» и многому другому.",
                            Question = "Почему я не могу просто заплатить больше и смотреть весь контент в подписке?"
                        },
                        new
                        {
                            Id = 3,
                            Answer = "Отдельный вид прав (например, права на показ по подписке) может быть выкуплен каким-то сервисом эксклюзивно для какой-то страны. Тогда только этот сервис может включить фильм в свою подписку. Но на других сервисах он может быть доступен по другим моделям (покупка или аренда), ведь это отдельный вид прав. Например, Amazon не лицензирует «Пацанов» в подписку никакой площадке в мире и не показывает его на ТВ, но вы можете купить этот сериал на КиноПоиске в Магазине.",
                            Question = "Понятно. А почему тогда некоторые фильмы и сериалы так и остаются в Магазине?"
                        },
                        new
                        {
                            Id = 4,
                            Answer = "Скорее всего, у нас истекли подписные права. Мы стремимся продлевать их, но, к сожалению, не можем гарантировать возвращение конкретного фильма или сериала в подписку и давать точные сроки, когда это произойдет.\r\n\r\nМы знаем, что неожиданное исчезновение фильма или сериала из подписки может сильно раздражать. Поэтому сейчас мы работаем над системой уведомлений и анонсов, чтобы вы могли успеть досмотреть то, что вы хотите.",
                            Question = "А что делать, если фильм или сериал исчез из подписки? Он вернется?"
                        },
                        new
                        {
                            Id = 5,
                            Answer = "По договору с правообладателем у нас должен быть временной интервал в 24 часа после выхода серии в США. Так что новые серии таких проектов, как «Чудотворцы», выходят у нас примерно в 10:30 следующего дня (если не возникает накладок с озвучкой).",
                            Question = "Почему серии некоторых сериалов выходят спустя сутки?"
                        },
                        new
                        {
                            Id = 6,
                            Answer = "Вы находитесь за границей или включили VPN.\r\n\r\nМы можем транслировать большинство зарубежных фильмов и сериалов только в РФ. На территории других стран права на эти же фильмы и сериалы принадлежат другим локальным сервисам — возможно, эксклюзивно. Поэтому показывать мы можем только то, на что у нас есть мировые права: наши сериалы, советскую классику и некоторые российские новинки.\r\n\r\nЕсли вы собираетесь смотреть КиноПоиск в отпуске, скачайте фильмы и сериалы заранее на телефон или планшет.",
                            Question = "Почему сервис стал рекомендовать мне только российские фильмы и сериалы и я не вижу большую часть каталога?"
                        },
                        new
                        {
                            Id = 7,
                            Answer = "У озвучек и субтитров тоже есть свои правообладатели. Мы стараемся сотрудничать с главными студиями (например, «Кубик в кубе», «Кураж-Бамбей» и Дима Сыендук) и релиз-группами (скажем, PhysKids), причем не только покупаем готовые, но и заказываем эксклюзивно для нас. Так, «Офис» был впервые полностью озвучен именно по заказу КиноПоиска.\r\n\r\nМы хотим добавить русские и оригинальные аудиодорожки и субтитры на все самые просматриваемые фильмы и сериалы на сервисе. До конца 2021 года мы планируем покрыть ими 80% активно просматриваемого каталога. А потом доберемся и до остального.\r\n\r\nЕще важно отметить, что для части фильмов и сериалов у нас никогда не будет оригинальных дорожек — все из-за ограничений правообладателей.",
                            Question = "Почему на сервисе нет моих любимых озвучек и не у всех зарубежных фильмов и сериалов есть субтитры?"
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Фантастика"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Боевик"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Триллер"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Приключения"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Биография"
                        },
                        new
                        {
                            Id = 6,
                            Name = "История"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Драма"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Военный"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Комедия"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Фэнтези"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Криминал"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Детектив"
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Model.GenreMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("GenreMovies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 2,
                            MovieId = 1
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 3,
                            MovieId = 1
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 4,
                            MovieId = 1
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 6,
                            MovieId = 2
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 7,
                            MovieId = 2
                        },
                        new
                        {
                            Id = 7,
                            GenreId = 9,
                            MovieId = 3
                        },
                        new
                        {
                            Id = 8,
                            GenreId = 7,
                            MovieId = 4
                        },
                        new
                        {
                            Id = 9,
                            GenreId = 8,
                            MovieId = 4
                        },
                        new
                        {
                            Id = 10,
                            GenreId = 7,
                            MovieId = 5
                        },
                        new
                        {
                            Id = 11,
                            GenreId = 10,
                            MovieId = 5
                        },
                        new
                        {
                            Id = 12,
                            GenreId = 11,
                            MovieId = 5
                        },
                        new
                        {
                            Id = 13,
                            GenreId = 12,
                            MovieId = 5
                        },
                        new
                        {
                            Id = 14,
                            GenreId = 7,
                            MovieId = 6
                        },
                        new
                        {
                            Id = 15,
                            GenreId = 1,
                            MovieId = 7
                        },
                        new
                        {
                            Id = 16,
                            GenreId = 4,
                            MovieId = 7
                        },
                        new
                        {
                            Id = 17,
                            GenreId = 7,
                            MovieId = 7
                        },
                        new
                        {
                            Id = 18,
                            GenreId = 7,
                            MovieId = 8
                        },
                        new
                        {
                            Id = 19,
                            GenreId = 11,
                            MovieId = 8
                        },
                        new
                        {
                            Id = 20,
                            GenreId = 1,
                            MovieId = 9
                        },
                        new
                        {
                            Id = 21,
                            GenreId = 2,
                            MovieId = 9
                        },
                        new
                        {
                            Id = 22,
                            GenreId = 3,
                            MovieId = 9
                        },
                        new
                        {
                            Id = 23,
                            GenreId = 7,
                            MovieId = 9
                        },
                        new
                        {
                            Id = 24,
                            GenreId = 12,
                            MovieId = 9
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreateYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateYear = "2021",
                            Description = "Более чем через год после тех событий журналист Эдди Брок пытается приспособиться к жизни в качестве хозяина инопланетного симбиота Венома, который наделяет его сверхчеловеческими способностями. Брок пытается возродить свою карьеру и берет интервью у серийного убийцы Клетуса Касади, который по воле случая становится хозяином Карнажа и сбегает из тюрьмы после неудавшейся казни.",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636022558/MoviePosters/Venom_2_wg6ejn.jpg",
                            Title = "Веном 2"
                        },
                        new
                        {
                            Id = 2,
                            CreateYear = "2021",
                            Description = "Нормандский рыцарь Жан де Карруж по возвращении с войны узнаёт, что его сосед и соперник Жак Ле Гри изнасиловал его жену Маргарит. Однако у Ле Гри обнаружились сильные союзники, словам женщины никто не верит, и Карруж обращается за помощью лично к королю Франции Карлу VI. Заслушав все свидетельства, король постановил, что конфликт должен быть разрешён в честном поединке. От исхода битвы зависит судьба не только Ле Гри и Карружа, но и жены последнего. В случае поражения мужа её должны сжечь на костре за ложные обвинения.",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Last_duel_e5rsyn.jpg",
                            Title = "Последняя дуэль"
                        },
                        new
                        {
                            Id = 3,
                            CreateYear = "2021",
                            Description = "Российская империя. Юрист Петр Смирнов приезжает в мрачное имение загадочного графа Дракулова, чьи предки родом из далекой Трансильвании, чтобы оформить покупку дома в Москве. Граф замечает фотокарточку невесты Петра, юной Вари, и немедленно срывается проинспектировать свою новую недвижимость… Петр обеспокоен, но его бдительность усыпляют старательные служанки графа. Правда, вскоре Смирнов обнаруживает, что девушки — вурдалаки, а это значит, что и их хозяин, граф Дракулов, — опасный кровопийца! Петр сбегает из демонической усадьбы и спешит в Москву, чтобы защитить свою невесту от трехсотлетнего вампира. Помочь ему в этом — или помешать — могут лучшая подруга Вари, Соня, и ее странные кавалеры, а также сын знаменитого профессора Ван Хельсинга Вася.",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Drakulov_pjwsdp.jpg",
                            Title = "Дракулов"
                        },
                        new
                        {
                            Id = 4,
                            CreateYear = "2021",
                            Description = "1944 год. Из Германии в оккупированное немцами село Михайловское в музей Пушкина приезжает профессор литературы Мария Шиллер и ведет просветительскую работу среди солдат вермахта и местных крестьян, рассказывая им о великом русском поэте. Ее действия вызывают неодобрение немецкого командования. Фронт приближается всё ближе, и вскоре из Берлина приходит приказ — вывезти из Михайловского все исторические ценности. Этого никак не могут допустить ни партизаны, ни местный умелец Сергей, которого связывают с Марией недопустимые, губительные для обоих отношения. Сергей решает любой ценой спасти достояние своей страны. Пушкинское наследие должно остаться в России. Даже ценой жизни…",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Uchenosti_Plody_iq3hkx.jpg",
                            Title = "Учености плоды"
                        },
                        new
                        {
                            Id = 5,
                            CreateYear = "1999",
                            Description = "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении, стал одним из самых необычных обитателей блока.",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Green_MIle_wt2y9b.jpg",
                            Title = "Зеленая миля"
                        },
                        new
                        {
                            Id = 6,
                            CreateYear = "1994",
                            Description = "Бухгалтер Энди Дюфрейн обвинён в убийстве собственной жены и её любовника. Оказавшись в тюрьме под названием Шоушенк, он сталкивается с жестокостью и беззаконием, царящими по обе стороны решётки. Каждый, кто попадает в эти стены, становится их рабом до конца жизни. Но Энди, обладающий живым умом и доброй душой, находит подход как к заключённым, так и к охранникам, добиваясь их особого к себе расположения.",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Shawshank_crz3n0.jpg",
                            Title = "Побег из Шоушенка"
                        },
                        new
                        {
                            Id = 7,
                            CreateYear = "2014",
                            Description = "Когда засуха, пыльные бури и вымирание растений приводят человечество к продовольственному кризису, коллектив исследователей и учёных отправляется сквозь червоточину (которая предположительно соединяет области пространства-времени через большое расстояние) в путешествие, чтобы превзойти прежние ограничения для космических путешествий человека и найти планету с подходящими для человечества условиями.",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Interstellar_utaka5.jpg",
                            Title = "Интерстеллар"
                        },
                        new
                        {
                            Id = 8,
                            CreateYear = "1994",
                            Description = "Двое бандитов Винсент Вега и Джулс Винфилд ведут философские беседы в перерывах между разборками и решением проблем с должниками криминального босса Марселласа Уоллеса. В первой истории Винсент проводит незабываемый вечер с женой Марселласа Мией. Во второй рассказывается о боксёре Бутче Кулидже, купленном Уоллесом, чтобы сдать бой. В третьей истории Винсент и Джулс по нелепой случайности попадают в неприятности.",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Pulp_Fiction_pwgblb.jpg",
                            Title = "Криминальное чтиво"
                        },
                        new
                        {
                            Id = 9,
                            CreateYear = "2010",
                            Description = "Кобб – талантливый вор, лучший из лучших в опасном искусстве извлечения: он крадет ценные секреты из глубин подсознания во время сна, когда человеческий разум наиболее уязвим. Редкие способности Кобба сделали его ценным игроком в привычном к предательству мире промышленного шпионажа, но они же превратили его в извечного беглеца и лишили всего, что он когда-либо любил. И вот у Кобба появляется шанс исправить ошибки. Его последнее дело может вернуть все назад, но для этого ему нужно совершить невозможное – инициацию. Вместо идеальной кражи Кобб и его команда спецов должны будут провернуть обратное. Теперь их задача – не украсть идею, а внедрить ее. Если у них получится, это и станет идеальным преступлением. Но никакое планирование или мастерство не могут подготовить команду к встрече с опасным противником, который, кажется, предугадывает каждый их ход. Врагом, увидеть которого мог бы лишь Кобб.",
                            Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Inception_uvkvsd.jpg",
                            Title = "Начало"
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Avatar = "https://res.cloudinary.com/pa2/image/upload/v1636538257/UserAvatars/kbroom135_gmail.com_xw2qe1.jpg",
                            Email = "kbroom135@gmail.com",
                            Gender = "Male",
                            Name = "Квит Кирилл Витальевич",
                            Password = "7uGP9aeazU4F7QhxLc3fEkBMcZn5AyQqeDq6MLxBO6Y=",
                            PhoneNumber = "+375295189484",
                            Role = "Admin",
                            Salt = new byte[] { 143, 188, 230, 183, 101, 3, 38, 186, 29, 23, 147, 73, 165, 102, 250, 161 }
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Model.Comment", b =>
                {
                    b.HasOne("Data_Access_Layer.Model.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Model.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data_Access_Layer.Model.CreditCard", b =>
                {
                    b.HasOne("Data_Access_Layer.Model.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data_Access_Layer.Model.GenreMovie", b =>
                {
                    b.HasOne("Data_Access_Layer.Model.Genre", "Genre")
                        .WithMany("GenreMovies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Model.Movie", "Movie")
                        .WithMany("GenreMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Data_Access_Layer.Model.Genre", b =>
                {
                    b.Navigation("GenreMovies");
                });

            modelBuilder.Entity("Data_Access_Layer.Model.Movie", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("GenreMovies");
                });

            modelBuilder.Entity("Data_Access_Layer.Model.User", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}