using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuffer;

    static List<ICommand> commandHistory;
    static int counter;

    //new code
    static Queue<ECommand> commandBufferE;

    static List<ECommand> commandHistoryE;
    static int counterE;

    private void Awake() 
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();

        //new code
        commandBufferE = new Queue<ECommand>();
        commandHistoryE = new List<ECommand>();
    }



    public static void AddCopmmand(ICommand command)
    {
        while(commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }
        
        commandBuffer.Enqueue(command);
    }

    // new code
    public static void AddCommand(ECommand commandE)
    {
        while (commandHistoryE.Count > counter)
        {
            commandHistoryE.RemoveAt(counter);
        }

        commandBufferE.Enqueue(commandE);
    }

    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();
            
            //commandBuffer.Dequeue().Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command history length: " + commandHistory.Count);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    counter--;
                    commandHistory[counter].Undo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter].Execute();
                    counter++;
                }
            }
        }

        //new but not very new code
        if (commandBufferE.Count > 0)
        {
            ECommand d = commandBufferE.Dequeue();
            d.ExecuteE();

            //commandBuffer.Dequeue().Execute();

            commandHistoryE.Add(d);
            counterE++;
            Debug.Log("Command history length: " + commandHistoryE.Count);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (counterE > 0)
                {
                    counterE--;
                    commandHistoryE[counterE].UndoE();
                }
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                if (counterE < commandHistoryE.Count)
                {
                    commandHistoryE[counterE].ExecuteE();
                    counterE++;
                }
            }
        }
    }


}
