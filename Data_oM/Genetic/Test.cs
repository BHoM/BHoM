using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Data.Genetic
{
    public interface IParentSelectionMethod : IObject
    {

    }
    public interface IFirstParentSelectionMethod : IParentSelectionMethod
    {

    }
    public interface ISecondParentSelectionMethod : IParentSelectionMethod
    {

    }

    public class RouletteWheelSelection : IFirstParentSelectionMethod, ISecondParentSelectionMethod
    {
    }

    public class RankSelection : IFirstParentSelectionMethod, ISecondParentSelectionMethod
    {
    }

    public class TournamentSelection : IFirstParentSelectionMethod, ISecondParentSelectionMethod
    {
        public int TournamentSize { get; set; } = 20;
    }

    public class DistanceBasedSelection : ISecondParentSelectionMethod
    {
        public double MinPercentile { get; set; } = 0.1;
        public double MaxPercentile { get; set; } = 0.25;
    }

    public interface ICrossoverMethod : IObject
    {
        double CrossoverRate { get; set; }
    }

    public class SinglePointCrossover : ICrossoverMethod
    {
        public double CrossoverRate { get; set; } = 0.7;
    }
    public class TwoPointCrossover : ICrossoverMethod
    {
        public double CrossoverRate { get; set; } = 0.7;
    }
    public class UniformCrossover : ICrossoverMethod
    {
        public double CrossoverRate { get; set; } = 0.7;
        public double Probability { get; set; } = 0.5;
    }
    public class ArithmeticCrossover : ICrossoverMethod
    {
        public double CrossoverRate { get; set; } = 0.7;
        public double Alpha { get; set; } = 0.5;
    }
    public class ProportionalArithmeticCrossover : ICrossoverMethod
    {
        public double CrossoverRate { get; set; } = 0.7;
    }
    public class BlendCrossover : ICrossoverMethod
    {
        public double CrossoverRate { get; set; } = 0.7;
        public double Alpha { get; set; } = 0.5;
    }
    public class SimulatedBinaryCrossover : ICrossoverMethod
    {
        public double CrossoverRate { get; set; } = 0.7;
        public double Eta { get; set; } = 2.0;
    }

    public interface IMutationMethod : IObject
    {
        double MutationRate { get; set; }
    }

    public class RandomPointMutation : IMutationMethod
    {
        public double MutationRate { get; set; } = 0.01;
    }

    public class GaussianPointMutation : IMutationMethod
    {
        public double MutationRate { get; set; } = 0.01;
        public int IntervalCount { get; set; } = 6;
    }

    public class GleamPointMutation : IMutationMethod
    {
        public double MutationRate { get; set; } = 0.01;
        public int IntervalCount { get; set; } = 6;
    }

    public interface IGeneticAlgorithmSettings : IObject
    {
        int PopulationSize { get; set; }
        double InitialBoost { get; set; }
        IFirstParentSelectionMethod SelectionMethod { get; set; }
        ICrossoverMethod CrossoverMethod { get; set; }
        IMutationMethod MutationMethod { get; set; }
        double ForceDropRatio { get; set; }
        double ForceMaintainRatio { get; set; }
    }

    public class FixedGenerationCount : IGeneticAlgorithmSettings
    {
        public int PopulationSize { get; set; } = 50;
        public double InitialBoost { get; set; } = 2;
        public IFirstParentSelectionMethod SelectionMethod { get; set; }
        public DistanceBasedSelection SecondParentSelectionMethod { get; set; }
        public ICrossoverMethod CrossoverMethod { get; set; }
        public IMutationMethod MutationMethod { get; set; }
        public double ForceMaintainRatio { get; set; } = 0.1;
        public double ForceDropRatio { get; set; } = 0.1;
        public int GenerationCount { get; set; } = 50;
    }

    public class DoubleParameter : IObject
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Step { get; set; }
    }

    public interface IGeneticAlgorithmResult : IObject
    {
        List<GenerationResult> Generations { get; set; }
    }

    public class GeneticAlgorithmResult : IGeneticAlgorithmResult
    {
        public List<GenerationResult> Generations { get; set; } = new List<GenerationResult>();
    }

    //TODO: needs to be IImmutable
    public class GenerationResult : IObject
    {
        public int GenerationNumber { get; set; }
        public List<Individual> Population { get; set; } = new List<Individual>();
    }

    //TODO: needs to be IImmutable
    public class Individual : IObject
    {
        public List<double> Genes { get; set; }
        public double Fitness { get; set; }
    }
}
