using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainPage : System.Web.UI.Page
{
    org.oorsprong.webservices.CountryInfoService service = new
        org.oorsprong.webservices.CountryInfoService();

    com.dneonline.www.Calculator MyCalc = new com.dneonline.www.Calculator();

    eu.dataaccess.footballpool.Info football = new eu.dataaccess.footballpool.Info();

    int no1, no2;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> names = new List<string>();

        foreach (org.oorsprong.webservices.tCountryCodeAndName CountryName in service.ListOfCountryNamesByName())
        {
            DropDownList1.Items.Add(CountryName.sName);
        }
    }

    protected void addBTN(object sender, EventArgs e)
    {
        no1 = Convert.ToInt32(number1.Text);
        no2 = Convert.ToInt32(number2.Text);

        resultLabel.Text =  MyCalc.Add(no1, no2).ToString();
    }

    protected void divideBTN(object sender, EventArgs e)
    {
        no1 = Convert.ToInt32(number1.Text);
        no2 = Convert.ToInt32(number2.Text);

        resultLabel.Text = MyCalc.Divide(no1, no2).ToString();
    }

    protected void MultiplyBTN(object sender, EventArgs e)
    {
        no1 = Convert.ToInt32(number1.Text);
        no2 = Convert.ToInt32(number2.Text);

        resultLabel.Text = MyCalc.Multiply(no1, no2).ToString();
    }

    protected void SubtractBTN(object sender, EventArgs e)
    {
        no1 = Convert.ToInt32(number1.Text);
        no2 = Convert.ToInt32(number2.Text);

        resultLabel.Text = MyCalc.Subtract(no1, no2).ToString();
    }

    protected void countriesBTN(object sender, EventArgs e)
    {
        string countryname = DropDownList1.SelectedItem.Text;

        string countryIsoCode = service.CountryISOCode(countryname);

        GridView1.DataSource = getDetails(countryIsoCode);
        GridView1.DataBind();
    }

    public List<Countries> getDetails(string CountryIso)
    {
        List<Countries> li = new List<Countries>();

        org.oorsprong.webservices.tCountryInfo income = service.FullCountryInfo(CountryIso);

        string langua = "";

        foreach (org.oorsprong.webservices.tLanguage d in income.Languages)
        {
            if (langua.Equals(""))
            {
                langua = d.sName;
            }
            else
            {
                langua = "," + d.sName;
            }
        }
        if (langua.Equals(""))
        {
            langua = "No language detected";
        }
        Countries C1 = new Countries(income.sName, income.sISOCode, income.sCapitalCity, income.sPhoneCode,
            income.sContinentCode, income.sCurrencyISOCode, langua);

        Image1.ImageUrl = income.sCountryFlag;
        li.Add(C1);
        return li;
    }

    protected void footballBTN(object sender, EventArgs e)
    {
        eu.dataaccess.footballpool.tTopScorerTop5[] topscorer;
        topscorer = football.TopScorersList();
        List<string> TopScorers = new List<string>();

        foreach (eu.dataaccess.footballpool.tTopScorerTop5 topSc in topscorer)
        {
            TopScorers.Add(topSc.sName + "," + topSc.iGoals);
        }
        Label3.Text = "TOP 5 SCORERS";
        Label1.Text = "CITIES NAMES";
        Label2.Text = "STADIUM NAMES";
        string[] stadiumNames = football.StadiumNames();
        string[] cities = football.CityNames();
        cityGV.DataSource = cities;
        cityGV.DataBind();

        stadiumGV.DataSource = stadiumNames;
        stadiumGV.DataBind();

        GridView2.DataSource = TopScorers;
        GridView2.DataBind();

    }

}   


