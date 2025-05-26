class TypeHead {
    static class Trie {
        Trie[] children = new Trie[26];
        ArrayList<String> sugg = new ArrayList<String>();
    }
    private HashMap<String, Double> searchTermFreq = new HashMap<String, Double>();
    private HashMap<String, Double> searchTermDecay = new HashMap<String, Double>();
    private Trie root = new Trie();
    private double decay = 1;
    
    public void incrementSearchTermFrequency(String search_term, int increment){
        Double newFreq = searchTermFreq.getOrDefault(search_term, (double)0) / (this.decay / searchTermDecay.getOrDefault(search_term, (double)1)) + increment;
        searchTermFreq.put(search_term, newFreq); 
        searchTermDecay.put(search_term, this.decay);
        int searchLength = search_term.length();
        Trie temp = root;
        for(int i=0;i<searchLength;++i) {
            int ch = search_term.charAt(i) - 'a';
            Trie child = temp.children[ch];
            if(child == null) {
                child = new Trie();
                child.sugg.add(search_term);
                temp.children[ch] = child;
            } else {
                boolean found = false;
                for(String str:child.sugg) {
                    if(str.equals(search_term)) {
                        found = true;
                        break;
                    }
                }
                if(found == false){
                    if(child.sugg.size() < 5) {
                        child.sugg.add(search_term);
                        sortSuggestions(child.sugg);
                   } 
                    else {
                        child.sugg.add(search_term);
                        sortSuggestions(child.sugg);
                        child.sugg.remove(5);
                    }
                }
            }
            temp = child;
        }
    }

    private void sortSuggestions(List<String> sugg) {
         sugg.sort( (s1, s2) -> {
            Double freq1 = searchTermFreq.get(s1) / (this.decay / (searchTermDecay.get(s1)));
            Double freq2 = searchTermFreq.get(s2) / (this.decay / (searchTermDecay.get(s2)));
            //compare their freq
            if(! freq1.equals(freq2)) {
                if(freq2 > freq1){
                    return 1;
                }
                return -1;
            }
            //if freq is same then lexicographical
            return s2.compareTo(s1);
        });
    }

    public String[] findTopXSuggestion(String queryPrefix, int X) {
        Trie temp = root;
        for(int i=0;i<queryPrefix.length();++i) {
            int ch = queryPrefix.charAt(i) - 'a';
            Trie child = temp.children[ch];
            if(child == null) {
                temp = null;
                break;
            }
            temp = child;
        }

        String[] suggestions = new String[X];
        if(temp == null) {
            Arrays.fill(suggestions, "");
            return suggestions;
        } else {
            sortSuggestions(temp.sugg);
            int count = 0;
            for(int i=0;i< Math.min(X, temp.sugg.size()); ++i) {
                suggestions[i] = temp.sugg.get(i);
                ++count;
            }
            for(int i=count;i<X;++i) {
                suggestions[i] = "";
            }
            Arrays.sort(suggestions, (s1, s2) -> s1.compareTo(s2));
            return suggestions;
        }
    }
    
    public void dayPasses(int decayFactor){
        this.decay *= decayFactor;
    }
};