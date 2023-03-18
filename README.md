# SOFT.PTML: Information Fusion (IF), Perturbation Theory (PT), Machine Learning (ML) Software.

Authors/Contributions:

Bernabé Ortega-Tenezaca (1,2) (Software Programming), GitHub: https://github.com/bernabeortega

Humbert González-Díaz (1,3,4,5) (Software Design, Paper Writing, Project Supervision), GitHub: https://github.com/glezdiazh
Linkedin: https://www.linkedin.com/in/humbertgdiaz/, Contact: humberto.gonzalezdiaz@ehu.eus

1 Departament of Organic and Inorganic Chemistry, Facultyof Science and Technology, 
Universityof The Basque Country UPV/EHU, Leioa, 48080,Basque Country, Spain.
2 Department of Computer Science and Information Technologies,
University of Coruña (UDC), 15071, A Coruña, Spain.
3BIOFISIKA: Basque Center for Biophysics, 48940, Leioa, Spain.
4Departament of Pharmacy, Faculty of Health Sciences, 
University CEU Cardenal Herrera, 46113, Moncada, Valencia, Spain.
5IKERBASQUE, Basque Foundation for Science, 48011, Bilbao, Spain.

E: mail: humberto.gonzalezdiaz@ehu.es

Background:

González-Díaz et al. coined the term NIFPTML = Network Invariant (NI) + Information Fusion (IF) + Perturbation Theory (PT) + Machine Learning (ML) to describe data analysis and multi-objective decission making strategies/algorithm for the training/validation of multi-output models for multi-objective optimization in input/output multi-label problems using information from multiple sensors/sources. It means, NIFPTML models can be used for multiple objective optimization/decission makig in the design, study, operation, or construction of a system/process by predicting with the same model multiple-ouputs for the same process/target system. NIFPTML takes into consideration that this target system/process may has multiple subsystems and/or may be composed by multiple process steps/phases each one with multiple ouput/input variables and multiple conditional labelling variables. As the name indicates NIFPTML algorithms include four main steps Network Invariant (NI) + Information Fusion (IF) + Perturbation Theory (PT) + Artificial Intelligence / Machine Learning (AI/ML).

Network Invariant (NI): NI-phase focus on the conceptualization of the system as a network-like structured system susceptible of being represented/studied as a complex system with at leas one or more sub-systems that can be represented as networks/graphs and studied with graph theory. This stage includes the calculation of multiple invariants (numerical parameters) such as mean properties, spectral moments, entropies, centralities, etc. that will be used to quantify the structure of the system. Typical network-like systems and their graphs representations are drugs molecular graphs, proteins contact map networks, metabolic pathway networks, protein interaction networks, brain co-activation networks, production plants networks, disease spreading and social networks, etc.

Information Fusion (IF): In this phase the algorithm performs the IF of all the information about different sub-systems or steps of the process collected from different sources. This phase also includes data pre-processing, data-rearragement, data engineering, missing data treatment, surrogate/synthetic data stages. IF phase finish with the creation of the working dataset. 

Perturbation Theory (PT): This dataset uses as input the working dataset created in IF phase. PT phase begins with the conceptualization of all input variables as structural descriptors (Dk), non-structural enviromental/process input/output variables, conditioning/labeling variables of all subsystems. PT phase finish with the calculation of multiple PT Operators (PTOs) used to quantify the input/output perturbations in target systems/process with respect to cases/populations of reference.

Artificial Intelligence / Machine Learning (AI/ML): Last AI/ML phase uses as input the PTOs to train/validate the AI/ML predictive algorithms and perform the prediction or properties and decission making on the design, discovery, or multi-objective optimization of the target system/process.

NIFPTML algorithms have been used in medicinal chemistry, proteomics, metabolomics, and nanotechnology, by different researchers. Typical systems/process studed with IFPTML algorithms are multi-objective decissin making in Drug Discovery (Anti-cancer, Anti-bacterial, Anti-parasites ... compounds screening), Fuel Production Plants (Fuel blending, Gasoline compoundig, Biofuel mixtures, Biofuel production protein enzymes...) optimization, Nanoparticle design (Anti-cancer co-therapy, Dual Activity Nanoparticles, ...), Materials properties optimization (Zeolites, Carbon based energy cells, etc.), Vaccine/Biomarkers design or discovery, etc. 

IFPTML begins with a first phase (IF) dedicated to carry out compilation and fusion of information of each sub-system or process step from different sources. 

Next the algorithm continues with the second phase (PT) focused on the transformation of the original values of the ouput variables vij into an objective function f(vij)obs and the orignal input variables into PT operators PTOs(Dk, cj). These PTOs are new input variables useful to codify at the same time information about the structural descriptors of the system Dkand multiple assay conditions cjfrom different sources. For instance, you can use PTOs to codify information about protein target, cell lines, microbial metabolic networks of target organism, nanoparticle carrier of the drug, etc. 

Last, IFPTML workflow enters into the ML phase that uses classic ML algorithms. 

Nevertheless, the process of development of this first IFPTML model and it posterior use for decission making was not implemented in a single software until recently. Until recently, the researchers aimed to training IFPTML models needed to run different software for each one of the different stages (IF, PT, and ML) of the algorithm. They needed to use calculation sheet/scripts to run the first phase, ML software/libraries to seek the model, and calculation sheet/scripts again to run predictions. 

This problem called the attention of software developers over the necessity of new platforms unifiying different steps of IFPMTL analysis. In fact, Ambure, Halder, González-Díaz, and Cordeiro introduced  QSAR-Co tool in order to solve some problems on this regard. QSAR-Co and posterior QSAR-CO-X version released to GitHub by Halder and Cordeiro (https://github.com/ncordeirfcup/QSAR-Co-X) are based on PTML algorithms an consequently run both PT and ML stages of the algorithm altogether. However, QSAR-Co is not able to run IF procedures for calculating multi-label PTOs able to encode multiple assay conditions/labels of different sub-systems/process at the same time. Strictly speaking, QSAR-Co models use a PTML algorithm and not an IFPTML algorithm able to perform IF phase. QSAR-Co only calculates one class of PT operators called single condition moving averages. Consequently, it needs as many PTOs as boundary conditions present on the problem. This implies a notably higher number of variables to be explored with respect to multi-label PTOs. 

Accordingly, Ortega-Tenezaca and González-Díaz introduced SOFT.PTML studio tool; this time including the possibility of calculating multi-label PTOs. This includes multi-label/multi-condition reference functions, moving averages, co-variances, etc. These PTOs, not present in QSAR-Co, have been very useful in order to reduce problem dimensionality in other problems. In fact, SOFT.PTMLhas been successfully used in IFPTML modeling nanotechnology and medicinal chemistry for this purpose as well.

SOFT.PTML Software References:

PTML Multi-Label Algorithms: Models, Software, and Applications. 
Ortega-Tenezaca B, Quevedo-Tumailli V, Bediaga H, Collados J, Arrasate S, 
Madariaga G, Munteanu CR, Cordeiro MNDS, González-Díaz H.
Curr Top Med Chem. 2020;20(25):2326-2337. doi: 10.2174/1568026620666200916122616.
 
Prediction of Antileishmanial Compounds: General Model, Preparation, and Evaluation of 2-Acylpyrrole Derivatives.
Santiago C, Ortega-Tenezaca B, Barbolla I, Fundora-Ortiz B, Arrasate S, Dea-Ayuela MA, González-Díaz H, Sotomayor N, Lete E.
J Chem Inf Model. 2022 Aug 22;62(16):3928-3940. doi: 10.1021/acs.jcim.2c00731.
 
IFPTML mapping of nanoparticle antibacterial activity vs. pathogen metabolic networks.
Ortega-Tenezaca B, González-Díaz H. Nanoscale. 2021 Jan 21;13(2):1318-1330. doi: 10.1039/d0nr07588d.

Chromosome Gene Orientation Inversion Networks (GOINs) of Plasmodium Proteome.
Quevedo-Tumailli VF, Ortega-Tenezaca B, González-Díaz H.
J Proteome Res. 2018 Mar 2;17(3):1258-1268. doi: 10.1021/acs.jproteome.7b00861. 
 
IFPTML Mapping of Drug Graphs with Protein and Chromosome Structural Networks vs. 
Pre-Clinical Assay Information for Discovery of Antimalarial Compounds.
Quevedo-Tumailli V, Ortega-Tenezaca B, González-Díaz H.
Int J Mol Sci. 2021 Dec 2;22(23):13066. doi: 10.3390/ijms222313066.

Other PTML, IFPTML, Algorithm References:

1: Simón-Vidal L, García-Calvo O, Oteo U, Arrasate S, Lete E, Sotomayor N,
González-Díaz H. Perturbation-Theory and Machine Learning (PTML) Model for High-
Throughput Screening of Parham Reactions: Experimental and Theoretical Studies.
J Chem Inf Model. 2018 Jul 23;58(7):1384-1396. doi: 10.1021/acs.jcim.8b00286.
Epub 2018 Jun 27. PMID: 29898360.

2: Santana R, Zuluaga R, Gañán P, Arrasate S, Onieva E, Montemore MM, González-
Díaz H. PTML Model for Selection of Nanoparticles, Anticancer Drugs, and
Vitamins in the Design of Drug-Vitamin Nanoparticle Release Systems for Cancer
Cotherapy. Mol Pharm. 2020 Jul 6;17(7):2612-2627. doi:
10.1021/acs.molpharmaceut.0c00308. Epub 2020 Jun 8. PMID: 32459098.

3: Vásquez-Domínguez E, Armijos-Jaramillo VD, Tejera E, González-Díaz H.
Multioutput Perturbation-Theory Machine Learning (PTML) Model of ChEMBL Data for
Antiretroviral Compounds. Mol Pharm. 2019 Oct 7;16(10):4200-4212. doi:
10.1021/acs.molpharmaceut.9b00538. Epub 2019 Aug 30. PMID: 31426639.

4: Blay V, Yokoi T, González-Díaz H. Perturbation Theory-Machine Learning Study
of Zeolite Materials Desilication. J Chem Inf Model. 2018 Dec
24;58(12):2414-2419. doi: 10.1021/acs.jcim.8b00383. Epub 2018 Sep 7. PMID:
30139249.

5: Diez-Alarcia R, Yáñez-Pérez V, Muneta-Arrate I, Arrasate S, Lete E, Meana JJ,
González-Díaz H. Big Data Challenges Targeting Proteins in GPCR Signaling
Pathways; Combining PTML-ChEMBL Models and [<sup>35</sup>S]GTPγS Binding Assays.
ACS Chem Neurosci. 2019 Nov 20;10(11):4476-4491. doi:
10.1021/acschemneuro.9b00302. Epub 2019 Nov 4. PMID: 31618004.

6: Bediaga H, Arrasate S, González-Díaz H. PTML Combinatorial Model of ChEMBL
Compounds Assays for Multiple Types of Cancer. ACS Comb Sci. 2018 Nov
12;20(11):621-632. doi: 10.1021/acscombsci.8b00090. Epub 2018 Oct 3. PMID:
30240186.

7: Ferreira da Costa J, Silva D, Caamaño O, Brea JM, Loza MI, Munteanu CR, Pazos
A, García-Mera X, González-Díaz H. Perturbation Theory/Machine Learning Model of
ChEMBL Data for Dopamine Targets: Docking, Synthesis, and Assay of New l-Prolyl-
l-leucyl-glycinamide Peptidomimetics. ACS Chem Neurosci. 2018 Nov
21;9(11):2572-2587. doi: 10.1021/acschemneuro.8b00083. Epub 2018 Jun 25. PMID:
29791132.

8: Santana R, Zuluaga R, Gañán P, Arrasate S, Onieva E, González-Díaz H.
Predicting coated-nanoparticle drug release systems with perturbation-theory
machine learning (PTML) models. Nanoscale. 2020 Jul 2;12(25):13471-13483. doi:
10.1039/d0nr01849j. PMID: 32613998.

9: Diéguez-Santana K, Casañola-Martin GM, Green JR, Rasulev B, González-Díaz H.
Predicting Metabolic Reaction Networks with Perturbation-Theory Machine Learning
(PTML) Models. Curr Top Med Chem. 2021;21(9):819-827. doi:
10.2174/1568026621666210331161144. PMID: 33797370.

10: Cabrera-Andrade A, López-Cortés A, Munteanu CR, Pazos A, Pérez-Castillo Y,
Tejera E, Arrasate S, González-Díaz H. Perturbation-Theory Machine Learning
(PTML) Multilabel Model of the ChEMBL Dataset of Preclinical Assays for
Antisarcoma Compounds. ACS Omega. 2020 Oct 15;5(42):27211-27220. doi:
10.1021/acsomega.0c03356. PMID: 33134682; PMCID: PMC7594149.

11: Santana R , Zuluaga R , Gañán P , Arrasate S , Onieva E , González-Díaz H .
Designing nanoparticle release systems for drug-vitamin cancer co-therapy with
multiplicative perturbation-theory machine learning (PTML) models. Nanoscale.
2019 Nov 21;11(45):21811-21823. doi: 10.1039/c9nr05070a. PMID: 31691701.

12: Concu R, D S Cordeiro MN, Munteanu CR, González-Díaz H. PTML Model of Enzyme
Subclasses for Mining the Proteome of Biofuel Producing Microorganisms. J
Proteome Res. 2019 Jul 5;18(7):2735-2746. doi: 10.1021/acs.jproteome.8b00949.
Epub 2019 Jun 4. PMID: 31081631.

13: Munteanu CR, Gutiérrez-Asorey P, Blanes-Rodríguez M, Hidalgo-Delgado I,
Blanco Liverio MJ, Castiñeiras Galdo B, Porto-Pazos AB, Gestal M, Arrasate S,
González-Díaz H. Prediction of Anti-Glioblastoma Drug-Decorated Nanoparticle
Delivery Systems Using Molecular Descriptors and Machine Learning. Int J Mol
Sci. 2021 Oct 26;22(21):11519. doi: 10.3390/ijms222111519. PMID: 34768951;
PMCID: PMC8584266.

14: Martínez-Arzate SG, Tenorio-Borroto E, Barbabosa Pliego A, Díaz-Albiter HM,
Vázquez-Chagoyán JC, González-Díaz H. PTML Model for Proteome Mining of B-Cell
Epitopes and Theoretical-Experimental Study of Bm86 Protein Sequences from
Colima, Mexico. J Proteome Res. 2017 Nov 3;16(11):4093-4103. doi:
10.1021/acs.jproteome.7b00477. Epub 2017 Oct 3. PMID: 28922600.

15: Barbolla I, Hernández-Suárez L, Quevedo-Tumailli V, Nocedo-Mena D, Arrasate
S, Dea-Ayuela MA, González-Díaz H, Sotomayor N, Lete E. Palladium-mediated
synthesis and biological evaluation of C-10b substituted
Dihydropyrrolo[1,2-b]isoquinolines as antileishmanial agents. Eur J Med Chem.
2021 Aug 5;220:113458. doi: 10.1016/j.ejmech.2021.113458. Epub 2021 Apr 16.
PMID: 33901901.

16: Sampaio-Dias IE, Rodríguez-Borges JE, Yáñez-Pérez V, Arrasate S, Llorente J,
Brea JM, Bediaga H, Viña D, Loza MI, Caamaño O, García-Mera X, González-Díaz H.
Synthesis, Pharmacological, and Biological Evaluation of 2-Furoyl-Based MIF-1
Peptidomimetics and the Development of a General-Purpose Model for Allosteric
Modulators (ALLOPTML). ACS Chem Neurosci. 2021 Jan 6;12(1):203-215. doi:
10.1021/acschemneuro.0c00687. Epub 2020 Dec 21. PMID: 33347281.

17: QSAR-Co: An Open Source Software for Developing Robust Multitasking or Multitarget Classification-Based QSAR Models.
Ambure P, Halder AK, González Díaz H, Cordeiro MNDS. J Chem Inf Model. 2019 Jun 24;59(6):2538-2544. doi: 10.1021/acs.jcim.9b00295.
