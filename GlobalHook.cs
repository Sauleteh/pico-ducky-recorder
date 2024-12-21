using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace PicoDucky
{
    private IKeyboardMouseEvents m_Events;

    private void SubscribeGlobal()
    {
        Unsubscribe();
        Subscribe(Hook.GlobalEvents());
    }

    private void Subscribe(IKeyboardMouseEvents events)
    {
        m_Events = events;
        m_Events.KeyDown += OnKeyDown;
        m_Events.KeyUp += OnKeyUp;
        m_Events.KeyPress += HookManager_KeyPress;
        m_Events.MouseUp += OnMouseUp;
        m_Events.MouseClick += OnMouseClick;
        m_Events.MouseDoubleClick += OnMouseDoubleClick;
        m_Events.MouseMove += HookManager_MouseMove;
        m_Events.MouseDragStarted += OnMouseDragStarted;
        m_Events.MouseDragFinished += OnMouseDragFinished;
        m_Events.MouseWheel += HookManager_MouseWheel;
        m_Events.MouseHWheel += HookManager_MouseHWheel;
        m_Events.MouseDown += OnMouseDown;
    }

    private void Unsubscribe()
    {
        if (m_Events == null) return;
        m_Events.KeyDown -= OnKeyDown;
        m_Events.KeyUp -= OnKeyUp;
        m_Events.KeyPress -= HookManager_KeyPress;
        m_Events.MouseUp -= OnMouseUp;
        m_Events.MouseClick -= OnMouseClick;
        m_Events.MouseDoubleClick -= OnMouseDoubleClick;
        m_Events.MouseMove -= HookManager_MouseMove;
        m_Events.MouseDragStarted -= OnMouseDragStarted;
        m_Events.MouseDragFinished -= OnMouseDragFinished;
        m_Events.MouseWheel -= HookManager_MouseWheel;
        m_Events.MouseHWheel -= HookManager_MouseHWheel;
        m_Events.MouseDown -= OnMouseDown;
        m_Events.Dispose();
        m_Events = null;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        Log(string.Format("KeyDown  \t\t {0}\n", e.KeyCode));
    }

    private void OnKeyUp(object sender, KeyEventArgs e)
    {
        Log(string.Format("KeyUp  \t\t\t {0}\n", e.KeyCode));
    }

    private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
    {
        Log(string.Format("KeyPress \t\t\t {0}\n", e.KeyChar));
    }

    private void HookManager_MouseMove(object sender, MouseEventArgs e)
    {
        labelMousePosition.Text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y);
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        Log(string.Format("MouseDown \t\t {0}\n", e.Button));
    }

    private void OnMouseUp(object sender, MouseEventArgs e)
    {
        Log(string.Format("MouseUp \t\t {0}\n", e.Button));
    }

    private void OnMouseClick(object sender, MouseEventArgs e)
    {
        Log(string.Format("MouseClick \t\t {0}\n", e.Button));
    }

    private void OnMouseDoubleClick(object sender, MouseEventArgs e)
    {
        Log(string.Format("MouseDoubleClick \t\t {0}\n", e.Button));
    }

    private void OnMouseDragStarted(object sender, MouseEventArgs e)
    {
        Log("MouseDragStarted\n");
    }

    private void OnMouseDragFinished(object sender, MouseEventArgs e)
    {
        Log("MouseDragFinished\n");
    }

    private void HookManager_MouseWheel(object sender, MouseEventArgs e)
    {
        labelWheel.Text = string.Format("Wheel={0:000}", e.Delta);
    }

    private void HookManager_MouseHWheel(object sender, MouseEventArgs e)
    {
        labelHWheel.Text = string.Format("HWheel={0:000}", e.Delta);
    }

    private void Log(string text)
    {
        if (IsDisposed) return;
        textBoxLog.AppendText(text);
        textBoxLog.AppendText(Environment.NewLine);
        textBoxLog.ScrollToCaret();
    }
}
