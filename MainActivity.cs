using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;

namespace LiftCalculator
{
    [Activity(Label = "Lift Calculator", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public double LiftForce_Factor = 1;
        public double Density_Factor = 1;
        public double Velocity_Factor = 1;
        public double Area_Factor = 1;
 //       public double LiftCoefficeint = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var imageView = FindViewById<ImageView>(Resource.Id.demoImageView);
            imageView.SetImageResource(Resource.Drawable.LiftCoefficientLIGHT2S);

            EditText ET_LiftForce = FindViewById<EditText>(Resource.Id.editTextLiftForce);
            EditText ET_Density = FindViewById<EditText>(Resource.Id.editTextDensity);
            EditText ET_Velocity = FindViewById<EditText>(Resource.Id.editTextVelocity);
            EditText ET_Area = FindViewById<EditText>(Resource.Id.editTextArea);
            EditText ET_LiftCoefficient = FindViewById<EditText>(Resource.Id.editTextLiftCoefficient);

            Button B_Lift = FindViewById<Button>(Resource.Id.liftForceButton);
            Button B_Density = FindViewById<Button>(Resource.Id.densityButton);
            Button B_Velocity = FindViewById<Button>(Resource.Id.velocityButton);
            Button B_Area = FindViewById<Button>(Resource.Id.areaButton);

            Button clear = FindViewById<Button>(Resource.Id.clearButton);
            clear.Click += (s, arg) => {
                ET_LiftForce.Text = "";
                ET_Density.Text = "";
                ET_Velocity.Text = "";
                ET_Area.Text = "";
                ET_LiftCoefficient.Text = "";
            };

            B_Lift.Click += (s, arg) => {
                PopupMenu menu = new PopupMenu(this, B_Lift);
                menu.Inflate(Resource.Menu.popup_menu);

                menu.MenuItemClick += (s1, arg1) => {
                    Console.WriteLine("{0} selected", arg1.Item.TitleFormatted);
                    ET_LiftForce.Hint = arg1.Item.TitleFormatted.ToString();
                    if (arg1.Item.TitleFormatted.ToString() == "Lift Force, (N)")
                        LiftForce_Factor = 1;
                    else if (arg1.Item.TitleFormatted.ToString() == "Lift Force, (Lbs)")
                        LiftForce_Factor = 4.45;
                    else
                        ET_LiftForce.Text = "CONVERSION ERROR";
                };
                menu.DismissEvent += (s2, arg2) => {
                    Console.WriteLine("menu dismissed");
                };

                menu.Show();
            };
            B_Density.Click += (s, arg) =>
            {
                PopupMenu menu = new PopupMenu(this, B_Density);
                menu.Inflate(Resource.Menu.popup_menu2);

                menu.MenuItemClick += (s1, arg1) =>
                {
                    Console.WriteLine("{0} selected", arg1.Item.TitleFormatted);
                    ET_Density.Hint = arg1.Item.TitleFormatted.ToString();
                    if (arg1.Item.TitleFormatted.ToString() == "Density, (kg/m^3)")
                        LiftForce_Factor = 1;
                    else
                        ET_Density.Text = "CONVERSION ERROR";
                };
                menu.DismissEvent += (s2, arg2) =>
                {
                    Console.WriteLine("menu dismissed");
                };

                menu.Show();
            };
            B_Velocity.Click += (s, arg) =>
            {
                PopupMenu menu = new PopupMenu(this, B_Velocity);
                menu.Inflate(Resource.Menu.popup_menu3);

                menu.MenuItemClick += (s1, arg1) =>
                {
                    Console.WriteLine("{0} selected", arg1.Item.TitleFormatted);
                    ET_Velocity.Hint = arg1.Item.TitleFormatted.ToString();
                    if (arg1.Item.TitleFormatted.ToString() == "Velocity, (m/s)")
                        Velocity_Factor = 1;
                    else if (arg1.Item.TitleFormatted.ToString() == "Velocity, (mph)")
                        Velocity_Factor = 0.44704;
                    else if (arg1.Item.TitleFormatted.ToString() == "Velocity, (km/h)")
                        Velocity_Factor = 0.277778;
                    else
                        ET_Velocity.Text = "CONVERSION ERROR";
                };
                menu.DismissEvent += (s2, arg2) =>
                {
                    Console.WriteLine("menu dismissed");
                };

                menu.Show();
            };
            B_Area.Click += (s, arg) => {
                PopupMenu menu = new PopupMenu(this, B_Area);
                menu.Inflate(Resource.Menu.popup_menu4);

                menu.MenuItemClick += (s1, arg1) => {
                    Console.WriteLine("{0} selected", arg1.Item.TitleFormatted);
                    ET_Area.Hint = arg1.Item.TitleFormatted.ToString();
                    if (arg1.Item.TitleFormatted.ToString() == "Area, (m)")
                        Area_Factor = 1;
                    else if (arg1.Item.TitleFormatted.ToString() == "Area, (ft)")
                        Area_Factor = 0.3048;
                    else
                        ET_Velocity.Text = "CONVERSION ERROR";
                };
                menu.DismissEvent += (s2, arg2) => {
                    Console.WriteLine("menu dismissed");
                };

                menu.Show();
            };



            ET_LiftForce.KeyPress += (object sender, View.KeyEventArgs e) => {
            e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    //Toast.MakeText(this, edittext.Text, ToastLength.Short).Show();
                    startCalculate( ET_LiftForce,  ET_Density,  ET_Velocity,  ET_Area,  ET_LiftCoefficient);
                    e.Handled = true;
                }
            };
            ET_Density.KeyPress += (object sender, View.KeyEventArgs e) => {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    //Toast.MakeText(this, edittext.Text, ToastLength.Short).Show();
                    startCalculate(ET_LiftForce, ET_Density, ET_Velocity, ET_Area, ET_LiftCoefficient);
                    e.Handled = true;
                }
            };
            ET_Velocity.KeyPress += (object sender, View.KeyEventArgs e) => {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    //Toast.MakeText(this, edittext.Text, ToastLength.Short).Show();
                    startCalculate(ET_LiftForce, ET_Density, ET_Velocity, ET_Area, ET_LiftCoefficient);
                    e.Handled = true;
                }
            };
            ET_Area.KeyPress += (object sender, View.KeyEventArgs e) => {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    //Toast.MakeText(this, edittext.Text, ToastLength.Short).Show();
                    startCalculate(ET_LiftForce, ET_Density, ET_Velocity, ET_Area, ET_LiftCoefficient);
                    e.Handled = true;
                }
            };
            ET_LiftCoefficient.KeyPress += (object sender, View.KeyEventArgs e) => {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    //Toast.MakeText(this, edittext.Text, ToastLength.Short).Show();
                    startCalculate(ET_LiftForce, ET_Density, ET_Velocity, ET_Area, ET_LiftCoefficient);
                    e.Handled = true;
                }
            };

        }

        private void startCalculate(EditText ET_LiftForce, EditText ET_Density, EditText ET_Velocity, EditText ET_Area, EditText ET_LiftCoefficient)
        {
            double LF = 0, D = 0, V = 0, A = 0, LC = 0;
            try { LF = Convert.ToDouble(ET_LiftForce.Text);
                LF *= LiftForce_Factor; } catch { }
            try { D = Convert.ToDouble(ET_Density.Text);
                D *= Density_Factor; } catch { }
            try { V = Convert.ToDouble(ET_Velocity.Text);
                V *= Velocity_Factor; } catch { }
            try { A = Convert.ToDouble(ET_Area.Text);
                A *= Area_Factor; } catch { }
            try { LC = Convert.ToDouble(ET_LiftCoefficient.Text); } catch { }

            if (LF == 0 && D != 0 && V != 0 && A != 0 && LC != 0)
            {
                CalculateLF(ET_LiftForce ,LC, D, V, A);
            }
            else if (LF != 0 && D == 0 && V != 0 && A != 0 && LC != 0)
            {
                CalculateD(ET_Density, LC, LF, V, A);
            }
            else if (LF != 0 && D != 0 && V == 0 && A != 0 && LC != 0)
            {
                CalculateV(ET_Velocity, LC, LF, D, A);
            }
            else if (LF != 0 && D != 0 && V != 0 && A == 0 && LC != 0)
            {
                CalculateA(ET_Area, LC, LF, V, D);
            }
            else if (LF != 0 && D != 0 && V != 0 && A != 0 && LC == 0)
            {
                CalculateLC(ET_LiftCoefficient, LF, D, V, A);
            }

        }

        private void CalculateLC(EditText LC, double Lift_Force, double Density, double Velocity, double Area)
        {
            double Lift_Coefficient = 0;
            Lift_Coefficient = (2 * Lift_Force) / ( Density * Velocity * Velocity * Area);
            LC.Text = Lift_Coefficient.ToString();
            //return Lift_Coefficient;
        }
        private void CalculateLF(EditText LF, double Lift_Coefficient, double Density, double Velocity, double Area)
        {
            double Lift_Force = 0;
            Lift_Force = (Lift_Coefficient * Density * Velocity * Velocity * Area) / 2;
            Lift_Force /= LiftForce_Factor;
            LF.Text = Lift_Force.ToString();
            //return Lift_Force;
        }
        private void CalculateD (EditText D, double Lift_Coefficient, double Lift_Force, double Velocity, double Area)
        {
            double Density = 0;
            Density = (2 * Lift_Force) / (Lift_Coefficient * Velocity * Velocity * Area);
            Density /= Density_Factor;
            D.Text = Density.ToString();
            //return Density;
        }
        private void CalculateV(EditText V, double Lift_Coefficient, double Lift_Force, double Density, double Area)
        {
            double Velocity = 0;
            Velocity = (2 * Lift_Force) / (Lift_Coefficient * Density * Area);
            try
            {
                Velocity = (double)Math.Sqrt(Velocity);
            }
            catch { }
            Velocity /= Velocity_Factor;
            V.Text = Velocity.ToString();
            //return Density;
        }
        private void CalculateA(EditText A, double Lift_Coefficient, double Lift_Force, double Velocity, double Density)
        {
            double Area = 0;
            Area = (2 * Lift_Force) / (Lift_Coefficient * Velocity * Velocity * Density);
            Area /= Area_Factor;
            A.Text = Area.ToString();
            //return Area;
        }

    }
}

