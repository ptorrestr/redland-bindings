#!/bin/bash
#declare SWIG_OPTS = "-I$(srcdir) -I$(srcdir)/.."
#swig -v -r $(SWIG_OPTS) -o Redland_wrap.c /usr/share/redland/Redland.i
swig -v -r -namespace -outdir redland/R -o redland/src/Redland_wrap.c Redland.i 
mv redland/R/NAMESPACE redland
cd redland/src
R CMD SHLIB Redland_wrap.c
