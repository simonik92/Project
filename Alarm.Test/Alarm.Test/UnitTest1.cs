using Xunit;
using Alarm;
using static Alarm.Program;

namespace Alarm.Test;

public class UnitTest1
{
    [Fact]
    public void CheckAlarm_SameTime_SameDay_True()
    {
        int countOfAlerts = 1;
        Alert[] alerts = new Program.Alert[countOfAlerts];
        Time time = new Time(12, 00);
        alerts[0] = new Alert(time, Days.Mo);
        Time timeToCheck = new Time(12, 00);
        Days dayToCheck = Days.Mo;
        Assert.True(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));

    }

    [Fact]
    public void CheckAlarm_TwoAlarmsSet_SameTime_SameDay_True()
    {
        int countOfAlerts = 2;
        Alert[] alerts = new Program.Alert[countOfAlerts];
        Time time1 = new Time(12, 00);
        Time time2 = new Time(8, 30);
        alerts[0] = new Alert(time1, Days.Mo);
        alerts[1] = new Alert(time2, Days.Fr);
        Time timeToCheck = new Time(12, 00);
        Days dayToCheck = Days.Mo;
        Assert.True(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));

    }

    [Fact]
    public void CheckAlarm_OneAlarmSet_SameTime_DifferentDay_False()
    {
        int countOfAlerts = 1;
        Alert[] alerts = new Program.Alert[countOfAlerts];
        Time time = new Time(12, 00);
        alerts[0] = new Alert(time, Days.Tu);
        Time timeToCheck = new Time(12, 00);
        Days dayToCheck = Days.Mo;
        Assert.False(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));

    }

    [Fact]
    public void CheckAlarm_OneAlarmSet_SameDay_DifferentTime_False()
    {
        int countOfAlerts = 1;
        Alert[] alerts = new Program.Alert[countOfAlerts];
        Time time = new Time(11, 00);
        alerts[0] = new Alert(time, Days.Tu);
        Time timeToCheck = new Time(12, 00);
        Days dayToCheck = Days.Tu;
        Assert.False(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));

    }

    [Fact]
    public void CheckAlarm_OneAlarmSet_DifferentDay_DifferentTime_False()
    {
        int countOfAlerts = 1;
        Alert[] alert = new Program.Alert[countOfAlerts];
        Time time = new Time(12, 00);
        alert[0] = new Alert(time, Days.Mo);
        Time timeToCheck = new Time(11, 30);
        Days dayToCheck = Days.Su;
        Assert.False(Program.CheckAlarm(alert, timeToCheck, dayToCheck));

    }

    [Fact]
    public void CheckAddDayToAlert_OneAlertSet_Same()
    {
        Time time = new Time(12, 00);
        Alert alert = new Alert(time, Days.Mo);
        Program.AddDayToAlert(ref alert, Days.Mo);
        Program.Days dayToCheck = Days.Mo;
        Assert.Equal(dayToCheck, alert.Days);

    }

    [Fact]

    public void CheckAddDayToAlert_OneAlertSet_AddNewDay_Same()
    {
        Time time = new Time(12, 00);
        Alert alert = new Alert(time, Days.Mo);
        Program.AddDayToAlert(ref alert, Days.Mo);
        Program.AddDayToAlert(ref alert, Days.Tu);
        Program.AddDayToAlert(ref alert, Days.We);
        Program.Days dayToCheck = Days.Mo|Days.Tu|Days.We;
        Assert.Equal(dayToCheck, alert.Days);

    }


}
