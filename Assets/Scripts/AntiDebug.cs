using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class AntiDebug : MonoBehaviour
{
    private static AntiDebug instance;


    [DllImport("kernel32.dll")]
    private static extern bool IsDebuggerPresent();

    [DllImport("kernel32.dll")]
    private static extern void CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InvokeRepeating("DebugCheck", 0f, 2f);
            // InvokeRepeating("DDLInjectionCheck", 0f, 2f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void DebugCheck()
    {
        bool hasDebugger = IsDebuggerPresent();

        if (!hasDebugger)
        {
            CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref hasDebugger);
        }

        if (hasDebugger || System.Diagnostics.Debugger.IsAttached)
        {
            EndAction();
        }
    }

    void DDLInjectionCheck()
    {
        Process currentProcess = Process.GetCurrentProcess();

        foreach (ProcessModule module in currentProcess.Modules)
        {
            IntPtr hModuleCheck = GetModuleHandle(module.ModuleName);

            // Compare base addresses of module and expected base address
            if (hModuleCheck != module.BaseAddress)
            {
                EndAction();
            }
        }
    }
    
    private void EndAction()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        if (GameObject.Find("Player") != null) Destroy(GameObject.Find("Player").GetComponent<PlayerMovement>());
        Invoke("QuitGame", 2f);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
