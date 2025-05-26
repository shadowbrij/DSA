class TypeHead {
    static class Trie {
        Trie[] children = new Trie[26];
        ArrayList<String> sugg = new ArrayList<String>();
    }
    private HashMap<String, Integer> searchTermFreq = new HashMap<String, Integer>();
    private Trie root = new Trie();

    public void incrementSearchTermFrequency(String search_term, int increment){
        int newFreq = searchTermFreq.getOrDefault(search_term, 0) + increment;
        searchTermFreq.put(search_term, newFreq);    
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
                        //compare their freq
                        if(! searchTermFreq.get(s1).equals(searchTermFreq.get(s2))) {
                            return searchTermFreq.get(s2) - searchTermFreq.get(s1);
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
};