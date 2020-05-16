using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_
{
    class Calculator_Fuction
    {
        private int MAXSIZE = 50;
        public struct SNode
        {
            public string[] Data;
            public int front;
            public int rear;
            //int Maxsize;
        };

        bool IsEmptySN(SNode S)
        {
            if (S.front == S.rear)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IsFullSN(SNode S)
        {
            if (MAXSIZE == S.rear)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IsOp(string S)
        {
            if (S == "+" || S == "-" || S == "*" || S == "/" || S == "(" || S == ")")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int WitchOp(string S)
        {
            if (S == "+")
            {
                return 0;
            }
            else if (S == "-")
            {
                return 1;
            }
            else if (S == "*")
            {
                return 2;
            }
            else if (S == "/")
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        SNode Pop(SNode S)
        {
            //string s;
            if (IsEmptySN(S))
            {
                //cout << "Stack is empty!" << endl;
                return S;
            }
            else
            {
                //s = S.Data[S.rear - 1];
                S.Data[S.rear - 1] = null;
                S.rear--;
                return S;
            }
        }

        SNode PopFront(SNode S)
        {
            //string s;
            if (IsEmptySN(S))
            {
                //cout << "Stack is empty!" << endl;
                return S;
            }
            else
            {
                //s = S.Data[S.front];
                S.Data[S.front] = null;
                S.front++;
                return S;
            }
        }

        SNode Push(SNode S, string St)
        {
            S.Data[S.rear++] = St;
            return S;
        }

        public SNode WriteIn(string S, int Lenth)
        {
            SNode s;
            s.Data = new string[50];
            s.front = 0;
            s.rear = 0;
            int i = 0;
            int j = 0;

            while (i<Lenth)
            {
                if (S[i] == ' ')
                {
                    i++;
                    j++;
                    s.rear++;
                }
                while (i<Lenth)
                {
                    s.Data[j] += S[i];
                    i++;
                    if (i < Lenth&&S[i] == ' ')
                    {
                        break;
                    }
                }
            }

            return s;
        }

        public SNode MidToRear(SNode S)
        {
            int p = 0;
            SNode r, op;
            r.Data = new string[50];
            r.rear = 0;
            r.front = 0;
            op.Data = new string[50];
            op.rear = 0;
            op.front = 0;
            //int pr = 0;

            while (S.Data[p] != null)
            {
                if (IsOp(S.Data[p]))
                {
                    if (IsEmptySN(op))
                    {
                        op = Push(op, S.Data[p]);
                        p++;
                    }
                    else
                    {
                        if (S.Data[p] == ")")
                        {
                            string o = op.Data[op.rear-1];
                            op = Pop(op);
                            while (o != "(")
                            {
                                r = Push(r, o);

                                o = op.Data[op.rear-1];
                                op = Pop(op);
                            }
                            p++;
                        }
                        else if (WitchOp(op.Data[op.rear - 1]) / 2 >= WitchOp(S.Data[p]) / 2)
                        {
                            if (op.Data[op.rear - 1] != "(")
                            {
                                string o = op.Data[op.rear-1];
                                op = Pop(op);
                                r = Push(r, o);
                                op = Push(op, S.Data[p]);
                            }
                            else
                            {
                                op = Push(op, S.Data[p]);
                            }
                            p++;
                        }
                        else
                        {
                            op = Push(op, S.Data[p]);
                            p++;
                        }
                    }
                }
                else if (!IsOp(S.Data[p]))
                {
                    r = Push(r, S.Data[p]);
                    p++;
                }
            }

            while (op.front != op.rear)
            {
                string o = op.Data[op.rear-1];
                op = Pop(op);
                r = Push(r, o);
            }

            return r;
        }

        public string Operation(SNode S)
        {
            SNode N;
            N.Data = new string[50];
            N.rear = 0;
            N.front = 0;
            double num1, num2;
            int op;
            double sum = 0;
            string st;

            while (S.front != S.rear)
            {
                st = S.Data[S.front];
                S = PopFront(S);
                string o;

                if (!IsOp(st))
                {
                    N.Data[N.rear++] = st;
                }
                else
                {
                    op = WitchOp(st);
                    o = N.Data[N.rear-1];
                    N = Pop(N);
                    num2 = Convert.ToDouble(o);
                    o = N.Data[N.rear-1];
                    N = Pop(N);
                    num1 = Convert.ToDouble(o);

                    switch (op)
                    {
                        case 0:
                            sum = num1 + num2;
                            break;
                        case 1:
                            sum = num1 - num2;
                            break;
                        case 2:
                            sum = num1 * num2;
                            break;
                        case 3:
                            //if (num2 == 0) 
                            sum = num1 / num2;
                            break;
                        default:
                            break;
                    }

                    N = Push(N, sum.ToString());
                }
            }

            return N.Data[N.front];
        }

        //public double Calculate(string Text)
        //{
        //    double value = 0;



        //    return value;
        //}
    }
}
