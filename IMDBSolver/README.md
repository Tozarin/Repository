# IMDBSolver

.NET course homework.
Collect films info from IMDB dumbs, store it (not now) and make reomendations (not now).

## Performance

All experiments are carried out on a laptop connected to the power supply without background programs.
Specifications: top secret

| feature | hwN | commit | fst | snd | thrd | 4th | estm | % from simple |
| ------- | --- | ------ | --- | --- | ---- | --- | ---- | ------------- |
| split parsing | 1 | --- | 1.24 | 1.24 | 1.25 | 1.23 | 1.24 | 100% |
| parsing without split | 2 | 23a9212 | 1.05 | 1.05 | 1.05 | 1.01 | 1.04 | 76% |
| previos + async | 2 | --- | 2.08 | 1.57 | 1.50 | 1.51 | 1.56 | 139% |
| Span insted string | 3 | 8404d4a | 1.14 | 1.15 | 1.13 | 1.13 | 1.14 | 88% |
| previos + async (not good) | 2 | --- | 2.08 | 1.57 | 1.50 | 1.51 | 1.56 | 139% |
| high lvl parall | 3-4 | f986de0 | 1.14 | 1.14 | 1.15 | 1.16 | 1.15 | 89% |
| early region match | 4 | e62e2e3 | 1.18 | 1.18 | 1.17 | 1.18 | 1.18 | 93% |
| improves pipeline | 4 | 1944c7b | 1.00 | 1.02 | 1.00 | 1.00 | 1.00 | 71% |
| Small improves to last | 4 | 80ff55c | 0.58 | 0.58 | 0.57 | 0.57 | 0.57 | 68% |