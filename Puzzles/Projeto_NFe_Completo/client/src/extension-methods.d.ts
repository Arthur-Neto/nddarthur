// tslint:disable-next-line:interface-name
interface Date {
    /**
       * Sobrescrita do método toJSON para que a data não sofra alteracão por
       * causa da UTC. Dessa forma, a conversão da data para JSON manterá exatamente
       * a mesma data informada incialmente na variavel.
    */
    toJSON(): string,
    /**
     * Retorna se a data é maior (1), igual (0) ou menor (-1) que a data passada por parametro.
     */
    compareDate(otherDate: Date): number,
}
