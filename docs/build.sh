#!/usr/bin/env bash

fname=$(echo "$1" | awk '{gsub(/.*[/]|[.].*/, "", $0)} 1')

mkdir -p dist

# Build
pdflatex -synctex=1 -interaction=nonstopmode "$fname.tex"
htlatex "$fname.tex" "xhtml,html5,mathml,charset=utf-8" " -cunihtf -utf8"
pandoc -o ${fname^^}.md "$fname.tex"
pandoc -s "$fname.tex" -o "$fname.docx"

cp "$fname.pdf" "dist/$fname.pdf"
cp "$fname.html" index.html

git clean  -d  -fx -f
rm -vf *.log *.aux "$fname.pdf"
