# Download Problems Script

This script downloads all Project Euler problem information from projecteuler.net and creates a consolidated `problems.md` file.

## Requirements

- Python 3.6+
- Required packages:
  - `requests`
  - `lxml`

## Installation

Install the required packages:

```bash
pip install requests lxml
```

## Usage

### Download All Problems (1-969)

```bash
python3 download_problems.py
```

This will create a `problems.md` file with all 969 problems.

### Download a Range of Problems

```bash
python3 download_problems.py --start 1 --end 100
```

### Test Mode (First 5 Problems Only)

```bash
python3 download_problems.py --test
```

### Custom Output File

```bash
python3 download_problems.py --output my_problems.md
```

### Custom Delay Between Requests

```bash
python3 download_problems.py --delay 1.0
```

### Command Line Arguments

- `--start N`: Starting problem number (default: 1)
- `--end N`: Ending problem number (default: 969)
- `--output FILE`: Output file name (default: problems.md)
- `--delay SECONDS`: Delay between requests in seconds (default: 0.5)
- `--test`: Test mode - only downloads problems 1-5

## How It Works

The script:

1. Fetches each problem page from `https://projecteuler.net/problem={ref}`
2. Extracts the title from the h2 tag at `/html/body/div[1]/div/h2`
3. Fetches the minimal page from `https://projecteuler.net/minimal={ref}`
4. Extracts the raw HTML description from `/html/body/pre`
5. Writes everything to a markdown file

The script includes a 0.5 second delay between requests to be respectful to the Project Euler server.

## Output Format

The generated `problems.md` file contains:

```markdown
# Project Euler Problems

Problems 1 to 969

---

## Problem 1: Multiples of 3 or 5

[Problem description in raw HTML]

---

## Problem 2: Even Fibonacci numbers

[Problem description in raw HTML]

---

...
```

## Example

```bash
# Download first 10 problems to a custom file
python3 download_problems.py --start 1 --end 10 --output first_10_problems.md

# Download all problems with a longer delay
python3 download_problems.py --delay 1.0
```

## Notes

- The script requires internet access to projecteuler.net
- Large ranges (all 969 problems) will take time due to the delay between requests
- If a problem cannot be fetched, it will be noted in the console output
- Error messages are printed to stderr for debugging
