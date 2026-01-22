#!/usr/bin/env python3
"""
Script to download all Project Euler problems information.
Creates a problems.md file with titles and descriptions from problems 1 to 969.

Note: This script requires internet access to projecteuler.net
"""

import sys
import time

try:
    import requests
    from lxml import html as lxml_html
except ImportError:
    print("Error: Required packages not installed.", file=sys.stderr)
    print("Please install: pip install requests lxml", file=sys.stderr)
    sys.exit(1)


def get_problem_title(problem_ref):
    """
    Get the problem title from the main problem page.
    
    Args:
        problem_ref: The problem reference number (1-969)
    
    Returns:
        The problem title string, or None if not found
    """
    url = f"https://projecteuler.net/problem={problem_ref}"
    try:
        response = requests.get(url, timeout=30)
        response.raise_for_status()
        
        tree = lxml_html.fromstring(response.content)
        # Extract title from h2 tag at /html/body/div[1]/div/h2
        title_elements = tree.xpath('/html/body/div[1]/div/h2')
        
        if title_elements:
            title = title_elements[0].text_content().strip()
            return title
        return None
    except Exception as e:
        print(f"Error fetching title for problem {problem_ref}: {e}", file=sys.stderr)
        return None


def get_problem_description(problem_ref):
    """
    Get the problem description from the minimal page.
    
    Args:
        problem_ref: The problem reference number (1-969)
    
    Returns:
        The problem description as raw HTML, or None if not found
    """
    url = f"https://projecteuler.net/minimal={problem_ref}"
    try:
        response = requests.get(url, timeout=30)
        response.raise_for_status()
        
        tree = lxml_html.fromstring(response.content)
        # Extract description from /html/body/pre
        pre_elements = tree.xpath('/html/body/pre')
        
        if pre_elements:
            # Get the raw HTML content from the pre tag
            description_html = lxml_html.tostring(pre_elements[0], encoding='unicode', method='html')
            # Remove the <pre> and </pre> tags
            description_html = description_html.replace('<pre>', '').replace('</pre>', '').strip()
            return description_html
        return None
    except Exception as e:
        print(f"Error fetching description for problem {problem_ref}: {e}", file=sys.stderr)
        return None


def download_all_problems(start=1, end=969, output_file="problems.md"):
    """
    Download all problems and create a markdown file.
    
    Args:
        start: Starting problem number (default: 1)
        end: Ending problem number (default: 969)
        output_file: Output markdown file name (default: problems.md)
    """
    print(f"Downloading problems {start} to {end}...")
    print(f"Output file: {output_file}")
    
    with open(output_file, 'w', encoding='utf-8') as f:
        f.write("# Project Euler Problems\n\n")
        f.write(f"Problems {start} to {end}\n\n")
        f.write("---\n\n")
        
        for ref in range(start, end + 1):
            print(f"Processing problem {ref}...", end=' ')
            
            title = get_problem_title(ref)
            description = get_problem_description(ref)
            
            if title and description:
                f.write(f"## Problem {ref}: {title}\n\n")
                f.write(f"{description}\n\n")
                f.write("---\n\n")
                print("✓")
            else:
                print(f"✗ (title: {'✓' if title else '✗'}, description: {'✓' if description else '✗'})")
                if title:
                    f.write(f"## Problem {ref}: {title}\n\n")
                    f.write("*Description not available*\n\n")
                    f.write("---\n\n")
            
            # Be nice to the server - add a small delay
            time.sleep(0.5)
    
    print(f"\n✓ Done! Problems saved to {output_file}")


if __name__ == "__main__":
    # Allow command line arguments for start and end
    import argparse
    
    parser = argparse.ArgumentParser(description='Download Project Euler problems')
    parser.add_argument('--start', type=int, default=1, help='Starting problem number (default: 1)')
    parser.add_argument('--end', type=int, default=969, help='Ending problem number (default: 969)')
    parser.add_argument('--output', type=str, default='problems.md', help='Output file (default: problems.md)')
    parser.add_argument('--test', action='store_true', help='Test mode - only download first 5 problems')
    
    args = parser.parse_args()
    
    if args.test:
        print("Running in test mode - downloading only problems 1-5")
        download_all_problems(start=1, end=5, output_file=args.output)
    else:
        download_all_problems(start=args.start, end=args.end, output_file=args.output)
