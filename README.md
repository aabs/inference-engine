
[![Build status](https://ci.appveyor.com/api/projects/status/lowjt20jtupg5m43/branch/master?svg=true)](https://ci.appveyor.com/project/aabs/inference-engine/branch/master)

# Inference Engine

This is a simple inference engine, available as a CLI tool, that will materialise inferences on a remote triple store.

## Caveats

1. It currently only properly implements the entailments defined for RDFS in the [RDF 1.1 Semantics](https://www.w3.org/TR/rdf11-mt/#patterns-of-rdfs-entailment-informative).
2. Not sure about performance characteristics - they haven't yet been tested
3. No incremental materialisation - currently only available in batch mode.
