using System;
using UnityEngine;

public class Weather
{
	public long Time;

	public float Cloudness;

	public float Wind;

	public int WindDirection;

	public float Turbulence;

	public float Rain;

	public float RainRandomness;

	public float ScaterringFogDensity;

	public float ScaterringFogHeight;

	public float GlobalFogDensity;

	public float GlobalFogHeight;

	public float Temperature;

	public float AtmospherePressure;

	public Vector2 MainWindPosition;

	public Vector2 MainWindDirection;

	public Vector2 TopWindPosition;

	public Vector2 TopWindDirection;

	public float LyingWater;

	public static Weather createNew()
	{
		Weather wtr = new Weather();
		wtr.Time = DateTime.UtcNow.Ticks;
		wtr.Cloudness = -0.3f;
		wtr.Wind = 4f;
		wtr.WindDirection = 7;
		wtr.Rain = 1f;
		wtr.RainRandomness = 0.5f;
		wtr.ScaterringFogDensity = 0.004f;
		wtr.Temperature = 20f;
		wtr.AtmospherePressure = 760f;
		wtr.LyingWater = 0f;
		wtr.Turbulence = 0f;
		wtr.ScaterringFogHeight = 0f;
		wtr.GlobalFogDensity = 0f;
		wtr.GlobalFogHeight = 0f;
		wtr.MainWindPosition = new Vector2(0f,0f);
		wtr.MainWindDirection = new Vector2(0f,0f);
		wtr.TopWindPosition = new Vector2(0f,0f);
		wtr.TopWindDirection = new Vector2(0f,0f);
		return wtr;
	}

	public override string ToString()
	{
		return string.Format(string.Concat("Time: ", Time, "\nCloudness: ", Cloudness, "\nWind: ", Wind, "\nWindDirection: ", WindDirection, "\nTurbulence: ", Turbulence, "\nRain: ", Rain, "\nRainRandomness: ", RainRandomness, "\nScaterringFogDensity: ", ScaterringFogDensity, "\nScaterringFogHeight: ", ScaterringFogHeight, "\nGlobalFogDensity: ", GlobalFogDensity, "\nGlobalFogHeight: ", GlobalFogHeight, "\nTemperature: ", Temperature, "\nAtmospherePressure: ", AtmospherePressure, "\nMainWindPosition: ", MainWindPosition, "\nMainWindDirection: ", MainWindDirection, "\nTopWindPosition: ", TopWindPosition, "\nTopWindDirection: ", TopWindDirection, "\nLyingWater: ", LyingWater, "\n"));
	}
}

