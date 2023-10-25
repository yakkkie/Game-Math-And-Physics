using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;


        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;




    }

    void Question2a()
    {
        //Draws only one line
        //setting a fixed start point and end point for the line 
        startPt = Vector2.zero;
        endPt = new Vector2(3   , 4);

        //put the args into getline which draws the line from the specified start point and endpoint
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

        //enables the line to be seen on the game world
        drawnLine.EnableDrawing(true);

        //calculates the magnitude
        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " +  vec2.magnitude);
    }

    void Question2b(int n)
    {
        //for loop for every line that ones to be drawn
        for (int i = 0; i < n; i++)
        {
            //randomising the starting point and the end point 
            startPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            endPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            //generates a rendom color for each line
            Color color = Random.ColorHSV();

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, color);

            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        //creates a 3d arrow with the specified starting and endpoints
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 5),
            Color.blue,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //randomising the endpoint for the arrows 
            Vector3 endPoint = new Vector3(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY),
                Random.Range(-maxY, maxY)
                );

            
            //creating random arrows which all start from the same origin
            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                endPoint,
                Random.ColorHSV(),
                60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a - b;


        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        // Your code here

        DebugExtension.DebugArrow(a.ToUnityVector3(), -b .ToUnityVector3(), Color.green, 60f);
        // Your code here

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a / 2;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(1,0,0), b.ToUnityVector3(), Color.green, 60f);
        
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3,5);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red,80f);

        a.Normalize();

        DebugExtension.DebugArrow(new Vector3(1,0,0), a.ToUnityVector3(), Color.green, 80f);

        Debug.Log("Magnitude = " + a.Magnitude().ToString("F2"));
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        // Your code here

        HVector2D proj = c.Projection(b);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
