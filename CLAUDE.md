# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository purpose

Personal Python practice repo for data structures & algorithms. The current branch (`dev/python-dsa`) is a greenfield Python rewrite — there is no Python source yet. The `master` branch holds a prior C# implementation kept for reference (see "Prior C# implementation" below).

## Data fixtures (`data/`)

Shared input datasets used by exercises and tests. Naming is meaningful and worth following when adding new fixtures:

- Size words map to counts: `ten`, `hundred`, `thousand`, `tenThousand`, `hundredThousand`, `million`, `tenMillion`. `twentyThousand` exists as a one-off (`twentyThousandSortedUnique.txt`).
- Base file (e.g. `tenThousand.txt`, `million.txt`) is a random sample at that size and **may contain duplicates** — `tenThousand.txt` has only ~6.3k unique values, `million.txt` ~632k. Small sizes (`hundred`, `thousand`) happen to be all-unique.
- `*Sorted.txt` — ascending; `*ReverseSorted.txt` — descending; `*Unique.txt` — deduplicated (and re-sampled from a larger range, so unique files are physically larger than their base).
- `primesMillion.txt` — first 1M primes, one per line. `primesMillionColumns.txt` — same primes but with a header line and 8-per-row column layout; do not assume one-int-per-line for files in this directory without checking.

These files are large (tenMillion is ~75 MB). Stream them line-by-line rather than loading entire files into memory.

## Testing

The user runs tests, but no framework has been chosen yet. When introducing the first tests, prefer `pytest` (run with `pytest` for the full suite, `pytest path/to/test_file.py::test_name` for a single test, `pytest -k "pattern"` for a name match, `pytest -q` for terse output). Place tests in `tests/` mirroring the source layout, and name files `test_*.py`.

For algorithms that touch the data fixtures, prefer parametrizing over the size variants so the same test exercises small inputs by default and larger ones on demand.

## Prior C# implementation (master branch)

The C# code on `master` establishes patterns the user has previously found useful — worth skimming if porting:

- `DSA/Common/` — shared primitives: `TreeNode`, `ListNode`, `IDataWarehouse` / `DataWarehouse` (data loader abstraction over the fixture files), `ISearch`.
- `DSA/TreesGraphs/` — `IBSTServices` / `BSTServices` (interface-first split, with services exposed via `DSAServices.cs`).
- `DSATests/` — separate test project; fixtures lived under `DSATests/Data/` (now hoisted to top-level `data/` on this branch).

When porting, the Python equivalent of the interface/service split is usually a single module — don't replicate the I-prefixed interfaces unless polymorphism is actually needed.
