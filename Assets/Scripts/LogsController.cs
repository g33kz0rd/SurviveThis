using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogsController : MonoBehaviour
{
    static private List<LogTime> logs = new List<LogTime>();
    static private GUIStyle style;

    private void Awake()
    {
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
            logs[i].time -= Time.deltaTime;
        }

        logs = logs.Where(x => x.time > 0).ToList();
    }

    static public void Log(string what, float duration = 1)
    {
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
        public float time;
        public string log;
    }
}
