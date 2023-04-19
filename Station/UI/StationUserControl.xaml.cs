using Station.DB;
using Station.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Station.UI;
/// <summary>
/// Логика взаимодействия для StationUserControl.xaml
/// </summary>
public partial class StationUserControl : UserControl
{
    public CreationContaineer CreationContaineer { get; set; }
    public bool CreationMode { get; set; }
    private DB.Station station { get; set; }
    private ObservableCollection<Shape> selectedElements = new ObservableCollection<Shape>();
    private ObservableCollection<RailPark> parks = new ObservableCollection<RailPark>();
     
    private Task serchPathTask;
    public StationUserControl() {
        InitializeComponent();

        OnStart();
        
    }
    public void SetStation(Station.DB.Station station) {

            MainGrupBox.IsEnabled = true;
            ClearAllViews();
            this.station = station;

            this.DataContext = this.station;
            foreach (RailCurve curve in station.ToRailCurves()) {
                AddStationElementToView(curve);
                //CreateLine(curve);
            }
            foreach (RailConnectionPoint p in station.ToRailConnections()) {
               // CreatePoint(p);
                AddStationElementToView(p);
            }
            
            loadParks();
     }

    #region loading
    private void OnStart() {
         
        KeyDown += StationUserControl_KeyDown;
        canvasView.Children.Clear();
        
        
        CreationContaineer = new CreationContaineer();
        SelectionView.Items.Clear();
        SelectionView.ItemsSource = selectedElements;
        ParksCombobox.Items.Clear();
        ParksCombobox.ItemsSource = parks;
        CreationMode = false;
        MainGrupBox.IsEnabled = false;
        Parks.Items.Clear();
        Parks.ItemsSource = parks;
        loadColorsSet();
    }

    private void StatusBar_Click(object sender, RoutedEventArgs e) {
      
    }

    private void loadColorsSet() {
        FillPattern.Items.Add(new ColorModel() { Color = Brushes.Blue, Name = "Синий" });
        FillPattern.Items.Add(new ColorModel() { Color = Brushes.Red, Name = "Красный" });
        FillPattern.Items.Add(new ColorModel() { Color = Brushes.Yellow, Name = "Желтый" });
    }
   
    private void loadParks() {

            parks.Clear();
            foreach (RailPark p in this.station.ToRailParks()) {

                parks.Add(p);
            }
       


        }

    #endregion

    #region Creation
    private void StationUserControl_KeyDown(object sender, KeyEventArgs e) {

        if (e.Key == Key.Escape) {

            if (CreationMode) {
                CancelEdit();
            }
            foreach (Shape l in this.selectedElements) {
                SetUIElementSelected(l, false);

            }
            selectedElements.Clear();
        }
        else if (e.Key == Key.Delete) {

            foreach (Shape l in this.selectedElements) {

                StationElement stationElement = l.Tag as StationElement;

                if(stationElement.IsPoint()) {

                    foreach(RailCurve curve in (stationElement as RailConnectionPoint).ConnectedCurves) {

                        Shape curveShape = GetShapeUIElementById(curve.Id);
                        if (curveShape != null) {

                            canvasView.Children.Remove(curveShape);
                        }
                    }
                }
                 
                canvasView.Children.Remove(l);
                station.RemoveElement(stationElement);
            }
           
            selectedElements.Clear();
        }
    }

    private void CancelEdit() {
        CreationContaineer.Reset();
        SetCreateionMode(false);
    }
    public Shape GetShapeUIElementById(int id) {
        Shape s = null;
        foreach(Shape i in canvasView.Children) {
            if(i.Tag==null) {
                continue;
            }
            if((i.Tag as StationElement).Id==id) {
                s= i;
                break;
            }
        }
        return s;

    }
    private void canvasView_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) {


        if (CreationMode) {
            Point p = Mouse.GetPosition(canvasView);
            double X = p.X;
            double Y = p.Y;
            RailConnectionPoint point = this.station.GetSimilarPoint(p.X, p.Y);

            if (point == null) {

                point = this.station.CreatePoint(X, Y);
                if (CreationContaineer.IsCreateSecondPoint()) {
                    RailConnectionPoint Start = CreationContaineer.Start;
                    if(point.IsSimilarByY(Start)) {
                        point.Y = Start.Y;
                    }
                }

              
                AddStationElementToView(point);
             
                
            }


            if (CreationContaineer.Start == null) {
                CreationContaineer.Start = point;
            }
            else if (CreationContaineer.End == null) {
                CreationContaineer.End = point;
                RailCurve curve = this.station.CreateCurve(CreationContaineer.Start, CreationContaineer.End);
                AddStationElementToView(curve);
                
               
                CreationContaineer.Reset();

            }


        }
    }
    
    private void AddStationElementToView(StationElement element) {

        Shape s = null;
        if(element.IsPoint()) {
            s = CreatePoint(element as RailConnectionPoint);
        }
        else if(element.IsCurve()) {
            s = CreateLine(element as RailCurve);
        }
         
        canvasView.Children.Add(s);
        
    }
    public Shape CreateLine(RailCurve curve) {

            Line line = new Line();
            line.Tag = curve;
            line.MouseDown += RailEment_mouseDown;

            line.X1 = curve.Start.X;
            line.Y1 = curve.Start.Y;
            line.X2 = curve.End.X;
            line.Y2 = curve.End.Y;

            // Create a red Brush  
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Gray;

            // Set Line's width and color  
            line.StrokeThickness = 4;
            line.Stroke = redBrush;
            //SetUIElementSelected(line, false);
            //canvasView.Children.Add(line);
            return line;
        }

    private void CreatePark_Click(object sender, RoutedEventArgs e) {
            if(selectedElements.Count == 0) {
                MessageBox.Show("Ничего не выбранно");
                return;
            }
            RailPark nPark= this.station.CreateRailPark();
            int count = parks.Count;
            nPark.Name = $"{nPark.Name} ({count})";

            foreach(Shape sel in selectedElements) {
            
                if(sel.Tag.GetType()==typeof(RailCurve)) {
                    nPark.AddSegment(sel.Tag as RailCurve);

                }
            
            }
            parks.Add(nPark);
        

        }
    public Shape CreatePoint(RailConnectionPoint p) {
            Ellipse ellipse = new Ellipse();
            ellipse.Tag = p;
            ellipse.Height = 10;
            ellipse.Width = 10;
            ellipse.Stroke = new SolidColorBrush(Colors.Gray);
            ellipse.Fill= new SolidColorBrush(Colors.Gray);
            ellipse.MouseLeftButtonDown += RailEment_mouseDown;
            ellipse.SetValue(Canvas.TopProperty, (p.Y - 5));
            ellipse.SetValue(Canvas.LeftProperty, (p.X - 5));
        
           // SetUIElementSelected(ellipse, false);
           // canvasView.Children.Add(ellipse);
            return ellipse;
        }
    #endregion

    
    private void ClearAllViews() {
        canvasView.Children.Clear();
        
    }

    private void SwithcEditModeButton_Click(object sender, System.Windows.RoutedEventArgs e) {

        SetCreateionMode(!CreationMode);
    }
    private void SetCreateionMode(bool val) {
        if (val) {
            SwithcEditModeButton.Content = "Выход из редактирования";
        }
        else {
            SwithcEditModeButton.Content = "Создать участок";
        }
        CreationMode = val;
    }

    
    

    private void RailEment_mouseDown(object sender, MouseButtonEventArgs e) {
        if (CreationMode == false) {


            Shape s = sender as Shape;
            StationElement st = s.Tag as StationElement;

            if(selectedElements.Contains(s)) {

               RemoveIdsFromSelect(new List<int>() { st.Id });
            }
            else {
                AddSelectedIds(new List<int>() { st.Id });
                 
            }
          
        }

    }

   
    private void SetStatusBar(string val) {
        Dispatcher.Invoke(new Action(() => {
            this.StatusBar.Text = val;
        }));
    }
    #region Selection
    private void SetUIElementSelected(Shape e, bool Selected) {
        SolidColorBrush br = null;
        if (Selected) {
            br = new SolidColorBrush(Colors.Red);
        }
        else {
            br = new SolidColorBrush(Colors.Gray);
        }
        e.Stroke = br;
        e.Fill= br;
    }  
   

    

     
    private void SetSelectedIDs(List<int> ids) {
        this.selectedElements.Clear();
        foreach(Shape shape in this.canvasView.Children) {
            StationElement st = shape.Tag as StationElement;
            if(st==null) {
                continue;
            }
            if(ids.Contains(st.Id)) {
                SetUIElementSelected(shape, true);
                this.selectedElements.Add(shape);
            }
            else {
                SetUIElementSelected(shape, false);
            }
        }
    }
    private void RemoveIdsFromSelect(List<int> ids) {
        foreach (Shape shape in this.canvasView.Children) {
            StationElement st = shape.Tag as StationElement;
            if (st == null) {
                continue;
            }
            if (ids.Contains(st.Id)) {
                SetUIElementSelected(shape, false);
                selectedElements.Remove(shape);
            }

        }
    }
    private void AddSelectedIds(List<int> ids) {
        foreach (Shape shape in this.canvasView.Children) {
            StationElement st = shape.Tag as StationElement;
            if (st == null) {
                continue;
            }
            if (ids.Contains(st.Id)) {
                SetUIElementSelected(shape, true);
                selectedElements.Add(shape);
            }
           
        }
    }
    



    private void Parks_SelectionChanged(object sender, SelectionChangedEventArgs e) {

       RailPark p= (sender as ListBox).SelectedItem as RailPark;
        if (p != null) {

            List<int> CurvesIds = p.GetCurvesIds();
            SetSelectedIDs(CurvesIds);
            DrawFigureForPark(p, Brushes.Blue);
        }
    }
    #endregion
    #region Serhing_events
    private async void SerchPath_Click(object sender, RoutedEventArgs e) {


        List<RailCurve> points = new List<RailCurve>();

        foreach(Shape s in this.selectedElements) {

            if(s.Tag.GetType()==typeof(RailCurve)) {
                points.Add(s.Tag as RailCurve);
            }
        }
        if(points.Count>2&&points.Count==0) {
            MessageBox.Show("Выберите 2 точки");
        }

        PathSercher sercher = new PathSercher();
        sercher.SetSerchigFrom(points[0], points[1]);
         
        
        sercher.OnFindShortestPath += Sercher_Iteration;
        sercher.OnSercjCompleate += Sercher_Compleate;
        sercher.OnSerchStart += Sercher_OnSerchStart;

        serchPathTask= Task.Run(sercher.RunSerch);



    }
 
    private void Sercher_OnSerchStart(CurvesPath path) {

        SetStatusBar("Поиск начат");
    }

    private void Sercher_Compleate(CurvesPath path) {

        SetStatusBar("Поиск завершен");
        

        List<int> ids = path.GetCurvesIds();
        Dispatcher.Invoke(new Action(() => {
            SetSelectedIDs(ids);
        }));

         
    }
    private void Sercher_Iteration(CurvesPath path) {

        

        List<int> ids = path.GetCurvesIds();
        Dispatcher.Invoke(new Action(() => {
            SetSelectedIDs(ids);
        }));
       
    
    }
    #endregion

    

    #region Fillig_park_area
    Polygon parkGigure;
    private void DrawFigureForPark(RailPark park,Brush Fill) {
        
        if(parkGigure!=null) {
            canvasView.Children.Remove(parkGigure);
        }
        PointsSorter sorter = new PointsSorter();
       
        if (park != null) {


            List<RailConnectionPoint> points = park.getPoints();
            sorter.Sort(points);
            points = sorter.GetSortedPoints();

             
            Polygon poly = CreatePoly(points,Fill);
            canvasView.Children.Add(poly);
            parkGigure = poly;
            
            

        }


    }
    private Polygon CreatePoly(List<RailConnectionPoint> points,Brush Fill) { 


        Polygon poly = new Polygon();
        poly.Fill = Fill;
        poly.Opacity = 0.2;

        foreach(RailConnectionPoint point in points) {
            poly.Points.Add(new Point() { X=point.X, Y=point.Y });
        }
        return poly;
        
    }

    private void Fill_Click(object sender, RoutedEventArgs e) {

        RailPark park=ParksCombobox.SelectedItem as RailPark;
        ColorModel br = FillPattern.SelectedItem as ColorModel;
        if(park != null&&br!=null) {

            DrawFigureForPark(park, br.Color);
        }
    }
    #endregion
}