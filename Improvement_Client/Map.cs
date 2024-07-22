using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml;
//using System.Device.Location;
using System.Net;

// Библиотеки для карты
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Drawing.Drawing2D;
using YandexDisk.Client.Http;
using YandexDisk.Client.Clients;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Improvement_Client.db;
namespace Improvement_Client
{
    public partial class Map : Form
    {
        // Класс точка - координаты
       


        public Map()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private db.Point firstPointForRoute;

        GMapOverlay PositionsForUser = new GMapOverlay("ПозицияпоЛКМ");
        GMapOverlay PositionForCircle = new GMapOverlay("ПозицияДляКруга");
        GMapOverlay ListOfTooltip = new GMapOverlay("Надписи");


        public int step = 0;
        public int mode = 0; //0 - ставится метка "нечищено"(красный дом),
                             //1 - ставится метка "очищено"(зеленый дом),
                             //2 - первая точка красной линии
                             //3 - вторая точка красной линии
                             //4 - первая точка зеленой линии
                             //5 - вторая точка зеленой линии
                             //6 - нечищено (красный подъезд)
                             //7 - очищено (зеленый подъезд)ч
        public int pointCounter = 0;
        // Список точек для учереждений
        

        public DiskHttpApi api = new DiskHttpApi("y0_AgAAAABzkYLhAAsiRgAAAAD4QPjlwCPtmN9lQim13fheo6nWPu0nFvY");
        public const string folderName = "Zhil";


        private async void gMapControl1_Load(object sender, EventArgs e)
        {
            // Создание элементов меню
            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Сохранить карту");

            /*       var roodFolderData = await api.MetaInfo.GetInfoAsync(new YandexDisk.Client.Protocol.ResourceRequest
                   {
                       Path = "/"
                   });
                   foreach(var item in roodFolderData.Embedded.Items)
                   {
                       MessageBox.Show($"{item.Name}\t{item.Type}\t{item.MimeType}");
                    }
                   if (!roodFolderData.Embedded.Items.Any(i => i.Type == YandexDisk.Client.Protocol.ResourceType.Dir && i.Name.Equals(folderName)))
                   {
                       await api.Commands.CreateDictionaryAsync("/" + folderName);

                   }*/



            
            ToolStripMenuItem GoogleMenuItem = new ToolStripMenuItem("Установить Google-карту");
            ToolStripMenuItem OpenCycleMapMenuItem = new ToolStripMenuItem("Установить OpenCycleMap-карту");

            ToolStripMenuItem ClearMap = new ToolStripMenuItem("Очистить карту");

            contextMenuStrip1.Items.AddRange(new[] { saveMenuItem, 
               GoogleMenuItem, OpenCycleMapMenuItem,ClearMap });

            gmap.ContextMenuStrip = contextMenuStrip1;

            saveMenuItem.Click += saveMenuItem_Click;
            GoogleMenuItem.Click += GoogleMenuItem_Click;
            OpenCycleMapMenuItem.Click += OpenCycleMapMenuItem_Click;
         

           
            ClearMap.Click += ClearMap_Click;

            // Настройки для компонента GMap
            gmap.Bearing = 0;
            // Перетаскивание левой кнопки мыши
            gmap.CanDragMap = true;
            // Перетаскивание карты левой кнопкой мыши
            gmap.DragButton = MouseButtons.Left;

            gmap.GrayScaleMode = true;

            // Все маркеры будут показаны
            gmap.MarkersEnabled = true;
            // Максимальное приближение
            gmap.MaxZoom = 18;
            // Минимальное приближение
            gmap.MinZoom = 2;
            // Курсор мыши в центр карты
            gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

            // Отключение нигативного режима
            gmap.NegativeMode = false;
            // Разрешение полигонов
            gmap.PolygonsEnabled = true;
            // Разрешение маршрутов
            gmap.RoutesEnabled = true;
            // Скрытие внешней сетки карты
            gmap.ShowTileGridLines = false;
            // При загрузке 10-кратное увеличение
            gmap.Zoom = 15;
            // Убрать красный крестик по центру
            gmap.ShowCenter = false;

            // Чья карта используется
            gmap.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(55.694749722260305, 37.820076275914545);

          

            // Для запросов
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;

            LoadIcons();
            LoadMarkers();
            LoadRoutes();
        }


        private List<db.Point_Image> allIcons;

        public async void LoadIcons()
        {

            HttpResponseMessage response = await Api.client.GetAsync(Api.APP_PATH + "/api/Point_Image");

            if (response.IsSuccessStatusCode)
            {
                var iconsJson = await response.Content.ReadAsStringAsync();
                allIcons = JsonConvert.DeserializeObject<List<Point_Image>>(iconsJson);
                //    DataGridReports.DataSource = allusers;

            }
            else
            {
                MessageBox.Show("Ошибка сервера!");
            }

        }


        

        // Отображение районов города
       
        // Очистка карты
        void ClearMap_Click(object sender, EventArgs e)
        {

        }

        // Сохранение изображения
        void saveMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dialogforsavemap = new SaveFileDialog())
                {
                    // Формат картинки
                    dialogforsavemap.Filter = "PNG (*.png)|*.png";

                    // Название картинки
                    dialogforsavemap.FileName = "Текущее положение карты";

                    Image image = gmap.ToImage();

                    if (image != null)
                    {
                        using (image)
                        {
                            if (dialogforsavemap.ShowDialog() == DialogResult.OK)
                            {
                                string fileName = dialogforsavemap.FileName;
                                if (!fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                    fileName += ".png";

                                image.Save(fileName);
                                MessageBox.Show("Карта успешно сохранена в директории: " + Environment.NewLine + dialogforsavemap.FileName, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
            }

            // Если ошибка
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка при сохранении карты: " + Environment.NewLine + exception.Message, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        // Смена поставщика карт
        void YandexMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.YandexMap;
            gmap.Zoom = 11;
            gmap.Position = new PointLatLng(55.696362, 37.824553);
        }

        void GoogleMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.Zoom = 11;
            gmap.Position = new PointLatLng(55.696362, 37.824553);
        }

        void OpenCycleMapMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.OpenCycleMap;
            gmap.Zoom = 11;
            gmap.Position = new PointLatLng(55.696362, 37.824553);
        }



        // Загрузить из файла координаты самому
    
        private void Map_Load(object sender, EventArgs e)
        {
            // Тебе не надо это смотри 10 и 11 часть
            //      StreamReader sr = new StreamReader(@"C:\Users\PC\Desktop\API.txt");
            //    myAPI = sr.ReadLine();

            //   trackBar1.Minimum = 0;
            trackBar1.Maximum = 360;

            //    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Найти меня - не работает


        /*      private void полигонОбластьToolStripMenuItem_Click(object sender, EventArgs e)
              {
                  gmap.Overlays.Add(MyPosition);
                  // CPoint Me = new CPoint(47.218930, 38.919681); // yes
                  CPoint Me = new CPoint(47.214828, 38.911777);   // no  
                  GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(Me.x, Me.y), GMarkerGoogleType.red_big_stop);
                  MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                  MarkerWithMyPosition.ToolTipText = "Ваше местоположение";
                  MyPosition.Markers.Add(MarkerWithMyPosition);
                  gmap.Overlays.Add(MyPosition);


                  List<PointLatLng> points = new List<PointLatLng>();
                  CPoint point1 = new CPoint(47.219538, 38.919806);
                  CPoint point2 = new CPoint(47.219350, 38.919666);
                  CPoint point3 = new CPoint(47.219283, 38.919865);
                  CPoint point4 = new CPoint(47.219473, 38.920003);

                  points.Add(new PointLatLng(point1.x, point1.y)); // левый вверх
                  points.Add(new PointLatLng(point2.x, point2.y)); // левый низ
                  points.Add(new PointLatLng(point3.x, point3.y)); // правый низ
                  points.Add(new PointLatLng(point4.x, point4.y)); // правый вверх

                  GMapPolygon polygon = new GMapPolygon(points, "МакДональдс");
                  polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                  polygon.Stroke = new Pen(Color.Red, 1);
                  polyOverlay.Polygons.Add(polygon);
                  gmap.Overlays.Add(polyOverlay);

                  double oX = (point1.x + point2.x + point3.x + point4.x) / 4;
                  double oY = (point1.y + point2.y + point3.y + point4.y) / 4;

                  CPoint pointofaveragebuild = new CPoint(oX, oY);

                  double x1 = pointofaveragebuild.x - Me.x;
                  double y1 = pointofaveragebuild.y - Me.y;
                  double res = Math.Sqrt(x1 * x1 + y1 * y1);

                  if (res < 0.009)
                      MessageBox.Show("Рядом с вами есть Мак");
                  else
                      MessageBox.Show("Рядом с вами нет Мака");
              } */

        private PointLatLng firstMarker;
        private PointLatLng secondMarker;
        private GMap.NET.WindowsForms.GMapOverlay markersOverlay = new GMap.NET.WindowsForms.GMapOverlay("markers");

        private void greenLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 4;
            //   MessageBox.Show("Поставьте первую точку линии");
        }

        // Добавление маркера по двойному клику ЛКМ по карте

        private List<db.Point> allMarkers;

        private List<Line> allLines;

        private async Task LoadMarkers()
        {
            PositionsForUser.Clear();
            allMarkers = new List<db.Point>();
            HttpResponseMessage response = await Api.client.GetAsync(Api.APP_PATH + "/api/points");

            if (response.IsSuccessStatusCode)
            {
                var markersJson = await response.Content.ReadAsStringAsync();
                allMarkers = JsonConvert.DeserializeObject<List<db.Point>>(markersJson);
                //    DataGridReports.DataSource = allusers;

            }
            else
            {
                MessageBox.Show("Ошибка сервера!");
            }




            foreach (db.Point marker in allMarkers)
            {

                double? x = marker.X;
                double? y = marker.Y;



                GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng((double)x, (double)y), ImagetoBitmap(marker.id_Point_ImageNavigation.Image));


                MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                MarkerWithMyPosition.ToolTipText = "Метка пользователя";
                PositionsForUser.Markers.Add(MarkerWithMyPosition);

            }

            gmap.Overlays.Add(PositionsForUser);
            gmap.Zoom--;
            gmap.Zoom++;

        }




        private async Task LoadRoutes()
        {
            try
            {

                allLines = new List<Line>();
                HttpResponseMessage response = await Api.client.GetAsync(Api.APP_PATH + "/api/lines");

                if (response.IsSuccessStatusCode)
                {
                    var linesJson = await response.Content.ReadAsStringAsync();
                    allLines = JsonConvert.DeserializeObject<List<Line>>(linesJson);
                    //    DataGridReports.DataSource = allusers;

                }
                else
                {
                    MessageBox.Show("Ошибка сервера!");
                }

                // Создание нового слоя для маршрутов
                GMapOverlay routesOverlay = new GMapOverlay("routes");

                foreach (Line line in allLines)
                {

                    // Создание точек маршрута
                    List<PointLatLng> points = new List<PointLatLng>();
                    points.Add(new PointLatLng((double)line.id_Point1Navigation.X, (double)line.id_Point1Navigation.Y));
                    points.Add(new PointLatLng((double)line.id_Point2Navigation.X, (double)line.id_Point2Navigation.Y));


                    // Создание маршрута и добавление его на слой
                    GMapRoute route = new GMapRoute(points, "");
                    route.Stroke = new Pen(line.Color == "Red" ? Color.Red : Color.Lime, 6);
                    routesOverlay.Routes.Add(route);
                }
                // Добавление слоя маршрутов на карту
                gmap.Overlays.Add(routesOverlay);
            }
            catch
            {
                MessageBox.Show("Линии не загружены");
            }
        }

        public Bitmap ImagetoBitmap(byte[] image)
        {
            Bitmap bitmap = null;
            using (MemoryStream stream = new MemoryStream(image))
            {
                bitmap = new Bitmap(stream);
            }
            return bitmap;

        }
        private async void gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {



            if (e.Button == MouseButtons.Left)
            {
                HttpResponseMessage response;

                if (mode == 0 || mode == 1 || mode == 6 || mode == 7)
                {
                    gmap.Overlays.Add(PositionsForUser);

                    db.Point myPoint = new db.Point();
                    myPoint.X = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
                    myPoint.Y = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                    myPoint.id_User = Api.userId;


                    // Широта - latitude - lat - с севера на юг
                    double x = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                    // Долгота - longitude - lng - с запада на восток
                    double y = gmap.FromLocalToLatLng(e.X, e.Y).Lat;



                    // Добавляем метку на слой
                    GMarkerGoogle MarkerWithMyPosition = null;



                    string type = "";
                    switch (mode)
                    {
                        case (0):
                            myPoint.Image = 1002;
                            MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(y, x), ImagetoBitmap(allIcons.Find(p => p.id_Point_Image == 1002).Image));


                            break;
                        case (1):
                            myPoint.Image = 2;
                            MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(y, x), ImagetoBitmap(allIcons.Find(p => p.id_Point_Image == 2).Image));

                            break;
                        case (6):
                            myPoint.Image = 1003;
                            MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(y, x), ImagetoBitmap(allIcons.Find(p => p.id_Point_Image == 1003).Image));

                            break;
                        case (7):
                            myPoint.Image = 1004;
                            MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(y, x), ImagetoBitmap(allIcons.Find(p => p.id_Point_Image == 1004).Image));

                            break;
                    }
                    var pointJson = JsonConvert.SerializeObject(myPoint);
                    var content = new StringContent(pointJson, Encoding.UTF8, "application/json");

                    response = await Api.client.PostAsync(Api.APP_PATH + "/api/points", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var myPointResult = await response.Content.ReadAsStringAsync();
                        myPoint = JsonConvert.DeserializeObject<db.Point>(myPointResult);
                    }


                    MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                    MarkerWithMyPosition.ToolTipText = "Метка пользователя";
                    PositionsForUser.Markers.Add(MarkerWithMyPosition);
                    allMarkers.Add(myPoint);


                }

                else if (mode == 2 || mode == 4)
                {
                    firstPointForRoute = new db.Point();
                    firstPointForRoute.X = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
                    firstPointForRoute.Y = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                    firstPointForRoute.Image = 1021;
                    gmap.Overlays.Add(PositionsForUser);


                    // Широта - latitude - lat - с севера на юг
                    double x = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                    // Долгота - longitude - lng - с запада на восток
                    double y = gmap.FromLocalToLatLng(e.X, e.Y).Lat;


                    // Добавляем метку на слой


                    var pointJson = JsonConvert.SerializeObject(firstPointForRoute);
                    var content = new StringContent(pointJson, Encoding.UTF8, "application/json");

                    response = await Api.client.PostAsync(Api.APP_PATH + "/api/points", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var firstPointResult = await response.Content.ReadAsStringAsync();
                        firstPointForRoute = JsonConvert.DeserializeObject<db.Point>(firstPointResult);
                    }
                    allMarkers.Add(firstPointForRoute);

                    GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(y, x), ImagetoBitmap(allIcons.Find(p => p.id_Point_Image == 1021).Image));

                    MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                    MarkerWithMyPosition.ToolTipText = "Метка пользователя";
                    PositionsForUser.Markers.Add(MarkerWithMyPosition);
                    allMarkers.Add(firstPointForRoute);
                    mode++;
                    //     MessageBox.Show("Поставьте вторую точку линии");
                }
                else if (mode == 3 || mode == 5)
                {
                    //    gmap.Overlays.Add(PositionsForUser);
                    db.Point secondPointForRoute = new db.Point();
                    secondPointForRoute.X = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
                    secondPointForRoute.Y = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                    secondPointForRoute.Image = 1021;
                    // Широта - latitude - lat - с севера на юг
                    double x = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                    // Долгота - longitude - lng - с запада на восток
                    double y = gmap.FromLocalToLatLng(e.X, e.Y).Lat;

                    var pointJson = JsonConvert.SerializeObject(secondPointForRoute);
                    var content = new StringContent(pointJson, Encoding.UTF8, "application/json");

                    response = await Api.client.PostAsync(Api.APP_PATH + "/api/points", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var secondPointResult = await response.Content.ReadAsStringAsync();
                        secondPointForRoute = JsonConvert.DeserializeObject<db.Point>(secondPointResult);
                    }
                    allMarkers.Add(secondPointForRoute);



                    GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(y, x), ImagetoBitmap(allIcons.Find(p => p.id_Point_Image == 1021).Image));

                    MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                    MarkerWithMyPosition.ToolTipText = "Метка пользователя";
                    PositionsForUser.Markers.Add(MarkerWithMyPosition);



                    // Добавляем метку на слой


                    firstMarker = (new PointLatLng((double)firstPointForRoute.X, (double)firstPointForRoute.Y));
                    secondMarker = (new PointLatLng((double)secondPointForRoute.X, (double)secondPointForRoute.Y));





                    GMapOverlay routes = new GMapOverlay("routes");
                    List<PointLatLng> points = new List<PointLatLng>();
                    points.Add(firstMarker);
                    points.Add(secondMarker);
                    GMapRoute route = new GMapRoute(points, "");
                    route.Stroke = new Pen((mode == 3 ? Color.Red : Color.Lime), 6);
                    routes.Routes.Add(route);
                    gmap.Overlays.Add(routes);

                    gmap.Zoom--;
                    gmap.Zoom++;
                    pointJson = JsonConvert.SerializeObject(firstPointForRoute);
                    content = new StringContent(pointJson, Encoding.UTF8, "application/json");

                    pointJson = JsonConvert.SerializeObject(secondPointForRoute);
                    content = new StringContent(pointJson, Encoding.UTF8, "application/json");


                    response = await Api.client.PostAsync(Api.APP_PATH + "/api/points", content);


                    Line newLine = new Line();
                    newLine.id_Point1 = firstPointForRoute.id_Point;
                    newLine.id_Point2 = secondPointForRoute.id_Point;

                    newLine.Color = (mode == 3 ? "Red" : "Green");

                    var lineJson = JsonConvert.SerializeObject(newLine);
                    content = new StringContent(lineJson, Encoding.UTF8, "application/json");

                    response = await Api.client.PostAsync(Api.APP_PATH + "/api/lines", content);
                    mode = 0;

                    //       MessageBox.Show("Линия успешно поставлена");
                }
            }
        }


        // Очистить все метки с карты
        private void greenLineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PositionsForUser.Clear();
            //ListWithPoinsOfUser.Clear();

        }



        // Расстояние между двумя точками
        private void redLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 2;
            //     MessageBox.Show("Поставьте первую точку линии");
        }


        // Отрисовка круга около маркера
        // -----------------------------------------------------------------------------
        private void CreateCircle(double lat, double lon, double radius, int ColorIndex)
        {
            PointLatLng point = new PointLatLng(lat, lon);
            int segments = 1080;

            List<PointLatLng> gpollist = new List<PointLatLng>();

            for (int i = 0; i < segments; i++)
                gpollist.Add(FindPointAtDistanceFrom(point, i * (Math.PI / 180), radius / 1000));

            GMapPolygon polygon = new GMapPolygon(gpollist, "Circle");
            switch (ColorIndex)
            {
                case 1:
                    polygon.Fill = new SolidBrush(Color.FromArgb(80, Color.Red));
                    break;
                case 2:
                    polygon.Fill = new SolidBrush(Color.FromArgb(80, Color.Orange));
                    break;
                case 3:
                    polygon.Fill = new SolidBrush(Color.FromArgb(20, Color.Aqua));
                    break;
                default:
                    //             MessageBox.Show("No search zone found!");
                    break;
            }
            polygon.Stroke = new Pen(Color.Red, 1);
            PositionForCircle.Polygons.Add(polygon);
            gmap.Overlays.Add(PositionForCircle);
        }
        public static PointLatLng FindPointAtDistanceFrom(PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = DegreesToRadians(startPoint.Lat);
            var startLonRad = DegreesToRadians(startPoint.Lng);

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));
            var endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos, distRatioCosine - startLatSin * Math.Sin(endLatRads));

            return new PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
        }
        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }
        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }
        public static double DistanceTwoPoint(double startLat, double startLong, double endLat, double endLong)
        {
            /* var startPoint = new PointLatLng(startLat, startLong);
            var endPoint = new GeoCoordinate(endLat, endLong);
            return startPoint.GetDistanceTo(endPoint); */
            return 2;

        }
        // -----------------------------------------------------------------------------



       
        

        // Нажатие на красный крестик формы
        private void Map_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    e.Cancel = false;
            //else
            //    e.Cancel = true;
        }


        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListOfTooltip.Clear();
       //     ListWithPoinsPlaces.Clear();
        }

      
        GMapRoute FindRouteWithPoint(GMapControl gmap, double targetLat, double targetLng)
        {
            // Округляем координаты для точного сравнения
            double roundedTargetLat = targetLat;
            double roundedTargetLng = targetLng;

            // Проходим по всем оверлеям на карте
            foreach (var overlay in gmap.Overlays)
            {
                // Проходим по всем маршрутам в оверлее
                foreach (var route in overlay.Routes)
                {
                    // Проходим по всем точкам маршрута
                    foreach (var point in route.Points)
                    {
                        double roundedPointLat = point.Lat;
                        double roundedPointLng = point.Lng;

                        if (roundedPointLat == roundedTargetLat && roundedPointLng == roundedTargetLng)
                        {
                            return route; // Маршрут найден
                        }
                    }
                }
            }

            return null; // Маршрут не найден
        }



        // Клик по маркеру чем-либо
        private async void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            // Если нажали ЛКМ по метке - выдать подробную ифну о маркере
            if (e.Button == MouseButtons.Left)
            {
                db.Point clickPoint = new db.Point();

                clickPoint = allMarkers.Where(p => p.X == item.Position.Lat && p.Y == item.Position.Lng).FirstOrDefault();

                HttpResponseMessage response = await Api.client.DeleteAsync(Api.APP_PATH + "/api/Points/" + clickPoint.id_Point);
                if (response.IsSuccessStatusCode)
                {
                    GMapOverlay overlay = item.Overlay;
                    overlay.Markers.Remove(item);
                    if (clickPoint.Image == 1021)
                    {
                        GMapRoute delRoute = FindRouteWithPoint(gmap, (double)clickPoint.X, (double)clickPoint.Y); ;
                        overlay.Routes.Remove(delRoute);


                        if (delRoute != null)
                        {
                            // Удаляем первую точку из маршрута
                            delRoute.Points.RemoveAll(p => p.Lat == (double)clickPoint.X && p.Lng == (double)clickPoint.Y);

                            // Проверяем, если осталась еще одна точка в маршруте
                            if (delRoute.Points.Count == 1)
                            {
                                var remainingPoint = delRoute.Points.First();
                                delRoute.Points.Remove(remainingPoint);

                                // Удаляем маркер для оставшейся точки с карты
                                GMapMarker remainingMarker = overlay.Markers.FirstOrDefault(m => m.Position.Lat == remainingPoint.Lat && m.Position.Lng == remainingPoint.Lng);
                                if (remainingMarker != null)
                                {
                                    overlay.Markers.Remove(remainingMarker);
                                }
                            }

                            // Если маршрут пуст, удаляем сам маршрут
                            if (delRoute.Points.Count == 0)
                            {
                                overlay.Routes.Remove(delRoute);
                                delRoute.Dispose();
                            }

                            // Обновление маршрута
                            gmap.UpdateRouteLocalPosition(delRoute);
                        }

                        // Обновление области карты
                        gmap.Invalidate();
                    
                
          
        
            /* gmap.Overlays.Clear();
             allMarkers.Clear();
             allLines.Clear();
             LoadMarkers();
             LoadRoutes(); */
        }

                }

          
            }

            // Если нажали слева на мышке вверху - удалить маркер
            if (e.Button == MouseButtons.XButton1)
            {
                // Узнаем слой удаляемого маркера
                GMapOverlay overlay = item.Overlay;
                // Удаляем в этом слое этот маркер
                overlay.Markers.Remove(item);

                // Сделать неведимым маркер
                // item.IsVisible = false;

                // Удалить весь слой при удалении одного маркера
                // gmap.Overlays.Remove(item.Overlay);
            }

            // Если нажали на колесо мыши - переимновать маркер по текстбоксу
            if (e.Button == MouseButtons.Middle)
            {

            }
        }



        // Наведение на маркер
        private void gmap_OnMarkerEnter(GMapMarker item)
        {
            //    MessageBox.Show("Ты навёл на меня. Зачем?");

            // textBox3.Text = item.Position.Lat.ToString();
            // textBox4.Text = item.Position.Lng.ToString();
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            gmap.Bearing = trackBar1.Value;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e) { }

        // Скачка карты
        private void button4_Click(object sender, EventArgs e)
        {
            RectLatLng area = gmap.SelectedArea;
            if (area.IsEmpty)
            {
                DialogResult res = MessageBox.Show("Нет области для скачивания", "Ошибка", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    area = gmap.ViewArea;
            }

            if (!area.IsEmpty)
            {
                DialogResult res = MessageBox.Show("Ready ripp at Zoom = " + (int)gmap.Zoom + " ?", "GMap.NET", MessageBoxButtons.YesNo);

                for (int i = 1; i <= gmap.MaxZoom; i++)
                {
                    if (res == DialogResult.Yes)
                    {
                        TilePrefetcher obj = new TilePrefetcher();
                        obj.ShowCompleteMessage = false;
                        obj.Start(area, i, gmap.MapProvider, 100, 0);

                    }
                    else if (res == DialogResult.No)
                        continue;
                    else if (res == DialogResult.Cancel)
                        break;
                }
            }
            else
                MessageBox.Show("Выбери площадь на карте с зажатой ATL", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        // Слой для маркеров аддресов
        GMapOverlay OverlayForAddress = new GMapOverlay("Address");
        // Ввод адреса в текстбокс и отобразить на карте координаты этого адреса
        private void button5_Click(object sender, EventArgs e)
        {
            gmap.MaxZoom = 18;
            // Минимальное приближение
            gmap.MinZoom = 2;
            // Курсор мыши в центр карты
            gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

            // Отключение нигативного режима
            gmap.NegativeMode = false;
            // Разрешение полигонов
            gmap.PolygonsEnabled = true;
            // Разрешение маршрутов
            gmap.RoutesEnabled = true;
            // Скрытие внешней сетки карты
            gmap.ShowTileGridLines = false;
            // При загрузке 10-кратное увеличение
            gmap.Zoom = 15;
            // Убрать красный крестик по центру
            gmap.ShowCenter = false;

            // Чья карта используется
            gmap.Position = new PointLatLng(55.694749722260305, 37.820076275914545);

        }


        // Слой для маркеров адресов по клику на карте
        GMapOverlay AddressClick = new GMapOverlay("AddressClick");

        // Клик по карте ПКМ и установка маркера с данными о нём
       
           

        // Слой для маркеров и маршрута
       
        // Маршрут из А в Б
     


        // Маршрутизация
        private void button6_Click(object sender, EventArgs e)
        {

        }


        // Панорама
        private void button7_Click(object sender, EventArgs e)
        {
        }
         

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите безвозвратно очистить  карту?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                PositionsForUser.Clear();
                ///ListWithPoinsOfUser.Clear();

                string filePath = @"Date\Координаты_ВыбранныеПользователем.txt";

                File.WriteAllText(filePath, string.Empty);

                filePath = @"Date\Routes.txt";

                File.WriteAllText(filePath, string.Empty);



                gmap.Overlays.Clear();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void clearedHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 1;
            //     MessageBox.Show("Выберите дома, которые хотите пометить как почищенные!");
        }

        private void clearedHouseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mode = 0;
            //    MessageBox.Show("Выберите дома, которые хотите пометить как нечищенные!");

        }

        private void clearedEntranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 7;
            //   MessageBox.Show("Выберите подъезды, которые хотите пометить как почищенные!"); 


        }

        private void clearedEntranceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mode = 6;
            //    MessageBox.Show("Выберите подъезды, которые хотите пометить как нечищенные!");
        }

        private void меткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите безвозвратно очистить  метки?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
 
                string filePath = @"Date\Координаты_ВыбранныеПользователем.txt";

                File.WriteAllText(filePath, string.Empty);





                gmap.Overlays.Clear();
            }
        }

      

        private async Task LoadFileAsync()
        {

        }


        private async void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {


        }

        private async void сСервераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите безвозвратно заменить свою карту на карту с сервера?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (FileInfo file in new DirectoryInfo(@"Date\").GetFiles())
                    {
                        file.Delete();
                    }


                    var roodFolderData = await api.MetaInfo.GetInfoAsync(new YandexDisk.Client.Protocol.ResourceRequest
                    {
                        Path = "/Zhil"
                    });

                    int i = 0;

                    foreach (var item in roodFolderData.Embedded.Items)
                    {
                        api.Files.DownloadFileAsync(path: item.Path, @"Date\" + item.Name);
                        var lnk = await api.Files.GetDownloadLinkAsync(item.Path);
                        //       MessageBox.Show(lnk.Href);

                        MessageBox.Show((i == 0 ? "Метки загружены" : "Линии загружены"));
                        i++;
                    }


                    Thread.Sleep(100);
                    Application.Restart();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка связи!");
            }
        }
        private void Map_Resize(object sender, EventArgs e)
        {
            // Установите желаемый размер для gmap
            int gmapWidth = this.ClientSize.Width * 3 / 4; // например, 75% ширины формы
            int gmapHeight = this.ClientSize.Height * 3 / 4; // например, 75% высоты формы

            // Размер и положение меню
            int menuHeight = menuStrip1.Height;

            // Размер и положение кнопки
            int button5Height = button5.Height;
            int button5Width = button5.Width;

            // Размер и положение trackBar
            int trackBarHeight = trackBar1.Height;

            // Централизуйте gmap
            gmap.Size = new Size(gmapWidth, gmapHeight);
            gmap.Location = new System.Drawing.Point(
                (this.ClientSize.Width - gmapWidth) / 2,
                menuHeight + button5Height + ((this.ClientSize.Height - menuHeight - button5Height - trackBarHeight - gmapHeight) / 2)
            );

            // Обновить положение и размер trackBar1
            trackBar1.Width = this.ClientSize.Width;
            trackBar1.Location = new System.Drawing.Point(0, this.ClientSize.Height - trackBarHeight);

            // Обновить положение button5
            button5.Location = new System.Drawing.Point((this.ClientSize.Width - button5Width) / 2, menuHeight);
        }

    }
}



    



