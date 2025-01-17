﻿using Data_Access_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data_Access_Layer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMovie> GenreMovies { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().Property(p => p.Name).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<User>().Property(p => p.PhoneNumber).HasDefaultValue("");
            modelBuilder.Entity<User>().Property(p => p.Avatar)
                .HasDefaultValue("https://res.cloudinary.com/pa2/image/upload/v1636535929/user_fhguim.png");

            modelBuilder.Entity<CreditCard>()
                .HasOne<User>(c => c.User)
                .WithMany(u => u.Cards)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<GenreMovie>()
                .HasOne(g => g.Genre)
                .WithMany(gm => gm.GenreMovies)
                .HasForeignKey(gi => gi.GenreId);

            modelBuilder.Entity<GenreMovie>()
                .HasOne(g => g.Movie)
                .WithMany(gm => gm.GenreMovies)
                .HasForeignKey(gi => gi.MovieId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(cu => cu.Comments)
                .HasForeignKey(ci => ci.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Movie)
                .WithMany(cu => cu.Comments)
                .HasForeignKey(ci => ci.MovieId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Ratings)
                .HasForeignKey(r => r.MovieId);

            //Filling

            modelBuilder.Entity<Rating>().HasData(new Rating
            {
                Id = 1,
                UserId = 1,
                MovieId = 1,
                Value = 5,
            });

            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                Id = 1,
                UserId = 1,
                MovieId = 1,
                Description = "Тестовый комментарий",
            });

            modelBuilder.Entity<CreditCard>().HasData(new CreditCard
            {
                Id = 1,
                UserId = 1,
                Cvc = "522",
                Number = "4556933079048353",
                Expiry = "04/22",
                CardHolderName = "KIRYL KVIT",
                Image = "https://res.cloudinary.com/pa2/image/upload/v1636633366/CreditCardImages/visa_qkcnbw.png",
            });

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Role = Role.Admin.ToString(),
                Name = "Квит Кирилл Витальевич",
                Email = "kbroom135@gmail.com",
                Gender = Gender.Male.ToString(),
                PhoneNumber = "+375295189484",
                Password = "7uGP9aeazU4F7QhxLc3fEkBMcZn5AyQqeDq6MLxBO6Y=",
                Salt = new byte[]
                {
                    143, 188, 230, 183, 101, 3, 38, 186, 29, 23, 147, 73, 165, 102, 250, 161
                },
                Avatar = "https://res.cloudinary.com/pa2/image/upload/v1636538257/UserAvatars/kbroom135_gmail.com_xw2qe1.jpg"
            });

            var genres = new List<string>()
            {
                "Фантастика", "Боевик", "Триллер",
                "Приключения", "Биография", "История",
                "Драма", "Военный", "Комедия",
                "Фэнтези", "Криминал", "Детектив",
            };

            for (var i = 1; i <= genres.Count; i++)
            {
                modelBuilder.Entity<Genre>().HasData(new Genre()
                {
                    Id = i,
                    Name = genres[i - 1],
                });
            }

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1,
                    Title = "Веном 2",
                    CreateYear = new DateTime(2021, 1, 1).ToString("yyyy"),
                    Description = "Более чем через год после тех событий журналист Эдди Брок пытается приспособиться к жизни в качестве хозяина инопланетного симбиота Венома," +
                                  " который наделяет его сверхчеловеческими способностями. Брок пытается возродить свою карьеру и берет интервью у серийного убийцы Клетуса Касади," +
                                  " который по воле случая становится хозяином Карнажа и сбегает из тюрьмы после неудавшейся казни.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022558/MoviePosters/Venom_2_wg6ejn.jpg"
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Последняя дуэль",
                    CreateYear = new DateTime(2021, 1, 1).ToString("yyyy"),
                    Description = "Нормандский рыцарь Жан де Карруж по возвращении с войны узнаёт, что его сосед и соперник Жак Ле Гри изнасиловал " +
                                  "его жену Маргарит. Однако у Ле Гри обнаружились сильные союзники, словам женщины никто не верит, и Карруж обращается" +
                                  " за помощью лично к королю Франции Карлу VI. Заслушав все свидетельства, король постановил, что конфликт должен быть " +
                                  "разрешён в честном поединке. От исхода битвы зависит судьба не только Ле Гри и Карружа, но и жены последнего. " +
                                  "В случае поражения мужа её должны сжечь на костре за ложные обвинения.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Last_duel_e5rsyn.jpg"
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Дракулов",
                    CreateYear = new DateTime(2021, 1, 1).ToString("yyyy"),
                    Description = "Российская империя. Юрист Петр Смирнов приезжает в мрачное имение загадочного графа Дракулова," +
                                  " чьи предки родом из далекой Трансильвании, чтобы оформить покупку дома в Москве. Граф замечает" +
                                  " фотокарточку невесты Петра, юной Вари, и немедленно срывается проинспектировать свою новую " +
                                  "недвижимость… Петр обеспокоен, но его бдительность усыпляют старательные служанки графа. " +
                                  "Правда, вскоре Смирнов обнаруживает, что девушки — вурдалаки, а это значит, что и их хозяин," +
                                  " граф Дракулов, — опасный кровопийца! Петр сбегает из демонической усадьбы и спешит в Москву, " +
                                  "чтобы защитить свою невесту от трехсотлетнего вампира. Помочь ему в этом — или помешать — могут" +
                                  " лучшая подруга Вари, Соня, и ее странные кавалеры, а также сын знаменитого профессора Ван Хельсинга Вася.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Drakulov_pjwsdp.jpg"
                },
                new Movie()
                {
                    Id = 4,
                    Title = "Учености плоды",
                    CreateYear = new DateTime(2021, 1, 1).ToString("yyyy"),
                    Description = "1944 год. Из Германии в оккупированное немцами село Михайловское в музей Пушкина приезжает профессор литературы" +
                                  " Мария Шиллер и ведет просветительскую работу среди солдат вермахта и местных крестьян, рассказывая им о великом " +
                                  "русском поэте. Ее действия вызывают неодобрение немецкого командования. Фронт приближается всё ближе, и вскоре из " +
                                  "Берлина приходит приказ — вывезти из Михайловского все исторические ценности. Этого никак не могут допустить ни партизаны," +
                                  " ни местный умелец Сергей, которого связывают с Марией недопустимые, губительные для обоих отношения. Сергей решает любой" +
                                  " ценой спасти достояние своей страны. Пушкинское наследие должно остаться в России. Даже ценой жизни…",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Uchenosti_Plody_iq3hkx.jpg"
                },
                new Movie()
                {
                    Id = 5,
                    Title = "Зеленая миля",
                    CreateYear = new DateTime(1999, 1, 1).ToString("yyyy"),
                    Description = "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников" +
                                  " которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых" +
                                  " и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении," +
                                  " стал одним из самых необычных обитателей блока.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Green_MIle_wt2y9b.jpg"
                },
                new Movie()
                {
                    Id = 6,
                    Title = "Побег из Шоушенка",
                    CreateYear = new DateTime(1994, 1, 1).ToString("yyyy"),
                    Description = "Бухгалтер Энди Дюфрейн обвинён в убийстве собственной жены и её любовника. Оказавшись в тюрьме" +
                                  " под названием Шоушенк, он сталкивается с жестокостью и беззаконием, царящими по обе стороны " +
                                  "решётки. Каждый, кто попадает в эти стены, становится их рабом до конца жизни. Но Энди, обладающий" +
                                  " живым умом и доброй душой, находит подход как к заключённым, так и к охранникам, добиваясь их " +
                                  "особого к себе расположения.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Shawshank_crz3n0.jpg"
                },
                new Movie()
                {
                    Id = 7,
                    Title = "Интерстеллар",
                    CreateYear = new DateTime(2014, 1, 1).ToString("yyyy"),
                    Description = "Когда засуха, пыльные бури и вымирание растений приводят человечество к продовольственному кризису" +
                                  ", коллектив исследователей и учёных отправляется сквозь червоточину (которая предположительно соединяет" +
                                  " области пространства-времени через большое расстояние) в путешествие, чтобы превзойти прежние ограничения" +
                                  " для космических путешествий человека и найти планету с подходящими для человечества условиями.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Interstellar_utaka5.jpg"
                },
                new Movie()
                {
                    Id = 8,
                    Title = "Криминальное чтиво",
                    CreateYear = new DateTime(1994, 1, 1).ToString("yyyy"),
                    Description = "Двое бандитов Винсент Вега и Джулс Винфилд ведут философские беседы в перерывах между разборками и" +
                                  " решением проблем с должниками криминального босса Марселласа Уоллеса. " +
                                  "В первой истории Винсент проводит незабываемый вечер с женой Марселласа Мией." +
                                  " Во второй рассказывается о боксёре Бутче Кулидже, купленном Уоллесом, чтобы сдать бой." +
                                  " В третьей истории Винсент и Джулс по нелепой случайности попадают в неприятности.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Pulp_Fiction_pwgblb.jpg"
                },
                new Movie()
                {
                    Id = 9,
                    Title = "Начало",
                    CreateYear = new DateTime(2010, 1, 1).ToString("yyyy"),
                    Description = "Кобб – талантливый вор, лучший из лучших в опасном искусстве извлечения: он крадет " +
                                  "ценные секреты из глубин подсознания во время сна, когда человеческий разум наиболее" +
                                  " уязвим. Редкие способности Кобба сделали его ценным игроком в привычном к предательству" +
                                  " мире промышленного шпионажа, но они же превратили его в извечного беглеца и лишили" +
                                  " всего, что он когда-либо любил. И вот у Кобба появляется шанс исправить ошибки." +
                                  " Его последнее дело может вернуть все назад, но для этого ему нужно совершить невозможное" +
                                  " – инициацию. Вместо идеальной кражи Кобб и его команда спецов должны будут провернуть " +
                                  "обратное. Теперь их задача – не украсть идею, а внедрить ее. Если у них получится, это и" +
                                  " станет идеальным преступлением. Но никакое планирование или мастерство не могут" +
                                  " подготовить команду к встрече с опасным противником, который, кажется, предугадывает каждый" +
                                  " их ход. Врагом, увидеть которого мог бы лишь Кобб.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Inception_uvkvsd.jpg"
                }
            );

            modelBuilder.Entity<GenreMovie>().HasData(new List<GenreMovie>()
            {
                new GenreMovie()
                {
                    Id = 1,
                    MovieId = 1,
                    GenreId = 1
                },
                new GenreMovie()
                {
                    Id = 2,
                    MovieId = 1,
                    GenreId = 2
                },
                new GenreMovie()
                {
                    Id = 3,
                    MovieId = 1,
                    GenreId = 3
                },
                new GenreMovie()
                {
                    Id = 4,
                    MovieId = 1,
                    GenreId = 4
                },
                new GenreMovie()
                {
                    Id = 5,
                    MovieId = 2,
                    GenreId = 6
                },
                new GenreMovie()
                {
                    Id = 6,
                    MovieId = 2,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 7,
                    MovieId = 3,
                    GenreId = 9
                },
                new GenreMovie()
                {
                    Id = 8,
                    MovieId = 4,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 9,
                    MovieId = 4,
                    GenreId = 8
                },
                new GenreMovie()
                {
                    Id = 10,
                    MovieId = 5,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 11,
                    MovieId = 5,
                    GenreId = 10
                },
                new GenreMovie()
                {
                    Id = 12,
                    MovieId = 5,
                    GenreId = 11
                },
                new GenreMovie()
                {
                    Id = 13,
                    MovieId = 5,
                    GenreId = 12
                },
                new GenreMovie()
                {
                    Id = 14,
                    MovieId = 6,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 15,
                    MovieId = 7,
                    GenreId = 1
                },
                new GenreMovie()
                {
                    Id = 16,
                    MovieId = 7,
                    GenreId = 4
                },
                new GenreMovie()
                {
                    Id = 17,
                    MovieId = 7,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 18,
                    MovieId = 8,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 19,
                    MovieId = 8,
                    GenreId = 11
                },
                new GenreMovie()
                {
                    Id = 20,
                    MovieId = 9,
                    GenreId = 1
                },
                new GenreMovie()
                {
                    Id = 21,
                    MovieId = 9,
                    GenreId = 2
                },
                new GenreMovie()
                {
                    Id = 22,
                    MovieId = 9,
                    GenreId = 3
                },
                new GenreMovie()
                {
                    Id = 23,
                    MovieId = 9,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 24,
                    MovieId = 9,
                    GenreId = 12
                }
            });

            modelBuilder.Entity<Faq>().HasData(new List<Faq>()
            {
                new Faq()
                {
                    Id = 1,
                    Question = "Почему не все фильмы и сериалы доступны на КиноПоиске по подписке?",
                    Answer = "Система прав на фильмы и сериалы устроена очень сложно — гораздо сложнее, чем, например," +
                             " на музыку.\r\n\r\nПрава приобретаются на определенное время и на конкретную территорию " +
                             "(страну).\r\n\r\nНа один и тот же фильм или сериал есть разные виды прав: публичный показ" +
                             " (прокат в кинотеатрах), покупка фильма навсегда, аренда, просмотр по подписке, показ по " +
                             "рекламной модели и т. д. Больше всего денег правообладатель и производитель зарабатывают на" +
                             " показе фильма в кинотеатре, меньше всего — на бесплатном показе с рекламой. Именно поэтому," +
                             " как правило, сначала фильм выходит в прокат. После окончания проката он появляется на " +
                             "видеосервисах, где его можно купить или взять в аренду. А еще через некоторое время он переходит" +
                             " в подписку.\r\n\r\nЕсли фильм пользуется популярностью и его продолжают покупать, то " +
                             "правообладатель может решить пока не продавать подписные права. Либо устанавливает такую цену " +
                             "за эти права, которые бы компенсировали ему деньги от распространения фильма по модели покупки." +
                             "\r\n\r\nПри этом каждый новый фильм или сериал — это зачастую отдельные договоренности с правообладателем." +
                             " Иногда стоимость подписных прав на фильм так высока, что мы понимаем: мы не сможем сохранить текущую" +
                             " стоимость нашей подписки Плюс (199 рублей в месяц) и включить в нее этот фильм.\r\n\r\nТе фильмы и" +
                             " сериалы, которые мы не смогли включить в подписку, остаются в Магазине. Вы можете купить их отдельно " +
                             "или взять в аренду и получить кешбэк, который потом можно потратить на что-то еще в Магазине или в" +
                             " других сервисах Плюса."
                },
                new Faq()
                {
                    Id = 2,
                    Question = "Почему я не могу просто заплатить больше и смотреть весь контент в подписке?",
                    Answer = "На КиноПоиске есть и более дорогие подписки. Например, Плюс с more.tv — за 399 рублей в месяц" +
                             " вы сможете смотреть их оригинальные и эксклюзивные проекты: от Happy End и «Регби» до «Великой»" +
                             " и «Рассказа служанки». А если оформите Плюс Мульти с Амедиатекой (699 рублей в месяц), получите" +
                             " доступ к контенту more.tv и свежим хитам и классике HBO и Showtime: «Миллиардам», «Воспитанным волками»," +
                             " «Сценам из супружеской жизни» и многому другому."
                },
                new Faq()
                {
                    Id = 3,
                    Question = "Понятно. А почему тогда некоторые фильмы и сериалы так и остаются в Магазине?",
                    Answer = "Отдельный вид прав (например, права на показ по подписке) может быть выкуплен каким-то сервисом " +
                             "эксклюзивно для какой-то страны. Тогда только этот сервис может включить фильм в свою подписку." +
                             " Но на других сервисах он может быть доступен по другим моделям (покупка или аренда), ведь это" +
                             " отдельный вид прав. Например, Amazon не лицензирует «Пацанов» в подписку никакой площадке в мире " +
                             "и не показывает его на ТВ, но вы можете купить этот сериал на КиноПоиске в Магазине."
                },
                new Faq()
                {
                    Id = 4,
                    Question = "А что делать, если фильм или сериал исчез из подписки? Он вернется?",
                    Answer = "Скорее всего, у нас истекли подписные права. Мы стремимся продлевать их, но, к сожалению, не " +
                             "можем гарантировать возвращение конкретного фильма или сериала в подписку и давать точные сроки," +
                             " когда это произойдет.\r\n\r\nМы знаем, что неожиданное исчезновение фильма или сериала из подписки" +
                             " может сильно раздражать. Поэтому сейчас мы работаем над системой уведомлений и анонсов, чтобы вы " +
                             "могли успеть досмотреть то, что вы хотите."
                },
                new Faq()
                {
                    Id = 5,
                    Question = "Почему серии некоторых сериалов выходят спустя сутки?",
                    Answer = "По договору с правообладателем у нас должен быть временной интервал в 24 часа после выхода серии в США." +
                             " Так что новые серии таких проектов, как «Чудотворцы», выходят у нас примерно в 10:30 следующего дня " +
                             "(если не возникает накладок с озвучкой)."
                },
                new Faq()
                {
                    Id = 6,
                    Question = "Почему сервис стал рекомендовать мне только российские фильмы и сериалы и я не вижу большую часть каталога?",
                    Answer = "Вы находитесь за границей или включили VPN.\r\n\r\nМы можем транслировать большинство зарубежных фильмов" +
                             " и сериалов только в РФ. На территории других стран права на эти же фильмы и сериалы принадлежат другим " +
                             "локальным сервисам — возможно, эксклюзивно. Поэтому показывать мы можем только то, на что у нас есть мировые" +
                             " права: наши сериалы, советскую классику и некоторые российские новинки.\r\n\r\nЕсли вы собираетесь смотреть " +
                             "КиноПоиск в отпуске, скачайте фильмы и сериалы заранее на телефон или планшет."
                },
                new Faq()
                {
                    Id = 7,
                    Question = "Почему на сервисе нет моих любимых озвучек и не у всех зарубежных фильмов и сериалов есть субтитры?",
                    Answer = "У озвучек и субтитров тоже есть свои правообладатели. Мы стараемся сотрудничать с главными студиями " +
                             "(например, «Кубик в кубе», «Кураж-Бамбей» и Дима Сыендук) и релиз-группами (скажем, PhysKids), причем " +
                             "не только покупаем готовые, но и заказываем эксклюзивно для нас. Так, «Офис» был впервые полностью" +
                             " озвучен именно по заказу КиноПоиска.\r\n\r\nМы хотим добавить русские и оригинальные аудиодорожки и" +
                             " субтитры на все самые просматриваемые фильмы и сериалы на сервисе. До конца 2021 года мы планируем " +
                             "покрыть ими 80% активно просматриваемого каталога. А потом доберемся и до остального.\r\n\r\nЕще важно" +
                             " отметить, что для части фильмов и сериалов у нас никогда не будет оригинальных дорожек — все из-за " +
                             "ограничений правообладателей."
                },
            });
        }
    }
}