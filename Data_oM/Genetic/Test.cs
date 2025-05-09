using BH.oM.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        public virtual int TournamentSize { get; set; } = 20;
    }

    public class DistanceBasedSelection : ISecondParentSelectionMethod
    {
        public virtual double MinPercentile { get; set; } = 0.1;
        public virtual double MaxPercentile { get; set; } = 0.25;
    }

    public interface ICrossoverMethod : IObject
    {
        double CrossoverRate { get; set; }
    }

    public class SinglePointCrossover : ICrossoverMethod
    {
        public virtual double CrossoverRate { get; set; } = 0.7;
    }
    public class TwoPointCrossover : ICrossoverMethod
    {
        public virtual double CrossoverRate { get; set; } = 0.7;
    }
    public class UniformCrossover : ICrossoverMethod
    {
        public virtual double CrossoverRate { get; set; } = 0.7;
        public virtual double Probability { get; set; } = 0.5;
    }
    public class ArithmeticCrossover : ICrossoverMethod
    {
        public virtual double CrossoverRate { get; set; } = 0.7;
        public virtual double Alpha { get; set; } = 0.5;
    }
    public class ProportionalArithmeticCrossover : ICrossoverMethod
    {
        public virtual double CrossoverRate { get; set; } = 0.7;
    }
    public class BlendCrossover : ICrossoverMethod
    {
        public virtual double CrossoverRate { get; set; } = 0.7;
        public virtual double Alpha { get; set; } = 0.5;
    }
    public class SimulatedBinaryCrossover : ICrossoverMethod
    {
        public virtual double CrossoverRate { get; set; } = 0.7;
        public virtual double Eta { get; set; } = 2.0;
    }

    public interface IMutationMethod : IObject
    {
        IMutationRate MutationRate { get; set; }
    }

    public class RandomPointMutation : IMutationMethod
    {
        public virtual IMutationRate MutationRate { get; set; } = null;
    }

    public class GaussianPointMutation : IMutationMethod
    {
        public virtual IMutationRate MutationRate { get; set; } = null;
        public virtual int IntervalCount { get; set; } = 6;
    }

    public class GleamPointMutation : IMutationMethod
    {
        public virtual IMutationRate MutationRate { get; set; } = null;
        public virtual int IntervalCount { get; set; } = 6;
    }

    public interface IMutationRate : IObject
    {

    }

    public class ConstantMutationRate : IMutationRate
    {
        public virtual double MutationRate { get; set; } = 0.01;
    }

    public class LinearMutationRate : IMutationRate
    {
        public virtual double InitialMutationRate { get; set; } = 0.2;
        public virtual double EndMutationRate { get; set; } = 0.01;
        public virtual int EndGeneration { get; set; } = 50;
    }

    public class ExponentialMutationRate : IMutationRate
    {
        public virtual double InitialMutationRate { get; set; } = 0.2;
        public virtual double EndMutationRate { get; set; } = 0.01;
        public virtual int EndGeneration { get; set; } = 50;
    }

    public class LogarithmicMutationRate : IMutationRate
    {
        public virtual double InitialMutationRate { get; set; } = 0.2;
        public virtual double EndMutationRate { get; set; } = 0.01;
        public virtual int EndGeneration { get; set; } = 50;
    }

    public class AdaptiveProportionalMutationRate : IMutationRate
    {
        public virtual double MinMutationRate { get; set; } = 0.01;
        public virtual double MaxMutationRate { get; set; } = 0.2;
    }


    public interface IGeneticAlgorithmSettings : IObject
    {
        int PopulationSize { get; set; }
        double InitialBoost { get; set; }
        IFirstParentSelectionMethod FirstParentSelectionMethod { get; set; }
        ISecondParentSelectionMethod SecondParentSelectionMethod { get; set; }
        ICrossoverMethod CrossoverMethod { get; set; }
        IMutationMethod MutationMethod { get; set; }
        double ForceDropRatio { get; set; }
        double ForceMaintainRatio { get; set; }
    }

    public class StandardGaSettings : IGeneticAlgorithmSettings
    {
        public virtual int PopulationSize { get; set; } = 50;
        public virtual double InitialBoost { get; set; } = 2;
        public virtual IFirstParentSelectionMethod FirstParentSelectionMethod { get; set; }
        public virtual ISecondParentSelectionMethod SecondParentSelectionMethod { get; set; }
        public virtual ICrossoverMethod CrossoverMethod { get; set; }
        public virtual IMutationMethod MutationMethod { get; set; }
        public virtual double ForceMaintainRatio { get; set; } = 0.1;
        public virtual double ForceDropRatio { get; set; } = 0.1;
        public virtual int MaxGenerationCount { get; set; } = 50;
        public virtual int MaxStagnant { get; set; } = 5;
    }

    public class DoubleParameter : IObject
    {
        public virtual double Min { get; set; }
        public virtual double Max { get; set; }
        public virtual double Step { get; set; }
    }

    public interface IGeneticAlgorithmResult : IObject
    {
        List<GenerationResult> Generations { get; set; }
    }

    public class GeneticAlgorithmResult : IGeneticAlgorithmResult
    {
        public virtual List<GenerationResult> Generations { get; set; } = new List<GenerationResult>();
    }

    public class GenerationResult : IImmutable
    {
        public virtual int GenerationNumber { get; } = 0;
        public virtual ReadOnlyCollection<Individual> Population { get; }
        public GenerationResult(int generationNumber, IList<Individual> population)
        {
            GenerationNumber = generationNumber;
            Population = new ReadOnlyCollection<Individual>(population);
        }
    }

    public class Individual : IImmutable
    {
        public virtual List<double> Genes { get; } = new List<double>();
        public virtual double Fitness { get; } = double.MinValue;

        public Individual(List<double> genes, double fitness)
        {
            Genes = genes;
            Fitness = fitness;
        }
    }
}
