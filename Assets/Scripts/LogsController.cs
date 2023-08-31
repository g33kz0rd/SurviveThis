using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogsController : MonoBehaviour
{
    static private List<LogTime> logs = new List<LogTime>();
    static private GUIStyle style;

    private void Update()
    {
        if (style != null)
            return;


        style = new GUIStyle()
        {
            font = Font.CreateDynamicFontFromOSFont("Consolas", 14)
        };
    }

    void OnGUI()
    {
        for (int i = 0; i < logs.Count; i++)
        {
            GUI.TextField(new Rect(0, 20 * i, logs[i].log.Length * 7, 20), $"{logs[i].log}", style);
            logs[i].time -= 16;
        }

        logs = logs.Where(x => x.time > 0).ToList();
    }

    static public void Log(string what, int duration = 30)
    {
        Debug.Log(what);
        var log = logs.FirstOrDefault(x => x.log == what);

        if (log != null)
            log.time = duration;
        else
            logs.Add(new LogTime()
            {
                log = what,
                time = duration,
            });
    }

    private class LogTime
    {
        public int time;
        public string log;
    }
}
